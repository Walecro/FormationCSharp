using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArgent
{
    public class Banque
    {
        // Zone de définition des chemins des fichiers
        const string pathcarte = "cartes.csv";
        const string pathcompte = "compte.csv";
        const string pathtrans = "trans.csv";
        const string pathwrite = "sortie.csv";

        public static void Main()
        {
            System.IO.Directory.SetCurrentDirectory(@"..\..\data");

            Compte c_dest, c_exp;
            List<List<double>> list_soldes = new List<List<double>>();
            List<double> soldes;
            List<string> OKs = new List<string>();

            // Récupération des objets dans les listes correspondantes
            List<Carte> car_l = EntreeSortie.ReadCarte(pathcarte);
            List<Compte> cpt_l = EntreeSortie.ReadCompte(pathcompte, car_l);
            List<Transaction> trs_l = EntreeSortie.ReadTrans(pathtrans, cpt_l);

            
            //Enregistrement des soldes avant toutes transactions
            soldes = new List<double>();
            foreach (Compte c in cpt_l)
            {
                soldes.Add(c._Solde);
            }
            list_soldes.Add(soldes);
            OKs.Add("    ");


            //boucle sur toutes les transactions du fichier 
            foreach (Transaction t in trs_l)
            {
                //Cas spécial, exp ou dest à 0  => Moins de vérification
                if (t._cpt_exp == 0)
                {
                    c_dest = cpt_l[t._cpt_dest - 1];

                    c_dest.Depot(t._montant);
                    OKs.Add("OK  ");

                }
                else if (t._cpt_dest == 0)
                {
                    c_exp = cpt_l[t._cpt_exp - 1];

                    if (c_exp.Prelevement(t))
                    {
                        OKs.Add("OK  ");
                    }
                    else
                    {
                        OKs.Add("KO  ");
                    }
                }
                // Autre   
                else
                {
                    //Récupération des comptes dans la liste (décalage de -1 d'id par rapport à indice à cause de 0 l'environnement
                    c_dest = cpt_l[t._cpt_dest - 1];
                    c_exp = cpt_l[t._cpt_exp - 1];

                    // Si les comptes sont tout deux courant OU que l'opération est intra compte  
                    // ET si le prélévement est un succès, on fait le virement sur le compte destinataire
                    if (((c_exp._type == Compte.TypeCompte.Courant && c_dest._type == c_exp._type) || c_dest._carte.Equals(c_exp._carte)) && c_exp.Prelevement(t) )
                    {
                        c_dest.Virement(t);
                        OKs.Add("OK  ");
                    }
                    else
                    {
                        OKs.Add("KO  ");
                    }
                }
                    soldes = new List<double>();
                    foreach( Compte c in cpt_l)
                    {
                        soldes.Add(c._Solde);
                    }
                    list_soldes.Add(soldes);
                 
            }
            Write_out(OKs,list_soldes);
            
            Console.ReadKey();
        }
        /// <summary>
        /// Fonction d'écriture dans un fichier de sortie csv du sommaire des transactions
        /// </summary>
        /// <param name="OK">La liste de string indicant la résolution d'une transaction</param>
        /// <param name="soldes">La liste des soldes des comptes au fur et à mesure des trasnsactions</param>
        private static void Write_out(List<string> OK, List<List<double>> soldes)
        {
            StringBuilder WriteBuffer = new StringBuilder();
            using (FileStream fs = File.Open(pathwrite, FileMode.OpenOrCreate))
            {
                for (int i = 0; i < OK.Count; i++)
                {
                    WriteBuffer.Append(OK[i] + "  ");
                    for (int j = 0; j < soldes[i].Count; j++)
                    {
                        WriteBuffer.Append(soldes[i][j] + " ");
                    }
                    WriteBuffer.Append("\n");
                    AddText(fs, WriteBuffer.ToString());
                    WriteBuffer.Clear();
                }
            }


        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
