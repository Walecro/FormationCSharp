using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArgent
{
    public class EntreeSortie

    {

        public static List<Compte> ReadCompte(string path,List<Carte> Carte_Liste)
        {
            List<Compte> Liste_Compte = new List<Compte>();
            Compte c_cur;
            int readLen;
            string[] readin;

            int id = 0;
            Compte.TypeCompte type = Compte.TypeCompte.Courant;
            Carte carte = null;
            double solde = -1;

            bool id_ok = false;
            bool type_ok = false;
            bool numcarte_ok = false;

            List<int> liste_id = new List<int>();

            using (FileStream fs = File.OpenRead(path))
            {
                //Méthode à revoir, implémenter / utiliser un readline , sinon ou troncature
                // Calculer nb byte exact ? sizeof? +1 ? \n
                byte[] b = new byte[1024];
                UTF8Encoding tempB = new UTF8Encoding(true);

                while ((readLen = fs.Read(b, 0, b.Length)) > 0)
                {
                    readin = tempB.GetString(b, 0, readLen).Split(';','\n');
                    for (int cpt = 0; cpt < readin.Length - 3; cpt += 4)
                    {
                        id_ok = int.TryParse(readin[cpt], out id);
                        if(id_ok && liste_id.Contains(id)){
                            id_ok = false;
                        }

                        foreach(Carte c in Carte_Liste)
                        {
                            if(c._numcarte == readin[cpt +1] )
                            {
                                carte = c;
                                numcarte_ok = true;
                            }
                        }

                        type_ok = Enum.TryParse<Compte.TypeCompte>( readin[cpt + 2], out type);

                        double.TryParse(readin[cpt + 3], out solde);

                        if (numcarte_ok && id_ok &&type_ok  ){
                            c_cur = new Compte(id, type, carte, solde);
                            Liste_Compte.Add(c_cur);
                            carte._Liste_Cpt.Add(c_cur);
                            liste_id.Add(id);
                            }
                    }

                     id_ok = false;
                     type_ok = false;
                     numcarte_ok = false;

                }
            }

            return Liste_Compte;
        }
        public static List<Carte> ReadCarte(string path)
        {
            List<Carte> Liste_Carte = new List<Carte>();
            int readLen;
            string[] readin;
            string numcarte = "";
            double plafond = 500;

            bool card_ok = false;
            bool plafond_ok = false;

            using (FileStream fs = File.OpenRead(path))
            {
                //Méthode à revoir, implémenter / utiliser un readline , sinon ou troncature
                // Calculer nb byte exact ? sizeof? +1 ? \n
                byte[] b = new byte[1024];
                UTF8Encoding tempB = new UTF8Encoding(true);

                while ((readLen = fs.Read(b, 0, b.Length)) > 0)
                {
                    readin = tempB.GetString(b, 0, readLen).Split(';','\n');
                    for (int cpt = 0; cpt < readin.Length - 1; cpt += 2)
                    {
                        if (readin[cpt].Length == 16)
                        {
                            card_ok = true;
                            numcarte = readin[cpt];
                        }


                        plafond_ok = double.TryParse(readin[cpt + 1], out plafond);
                        if (plafond_ok)
                        {

                            if (plafond > 3000.0 || plafond < 500.0)
                            {
                                plafond_ok = false;
                            }
                        }
                        else
                        {
                            plafond_ok = true;
                            plafond = 500;
                        }

                        if (card_ok && plafond_ok)
                        {
                            Liste_Carte.Add(new Carte(numcarte, plafond));
                        }
                    }
                    card_ok = false;
                    plafond_ok = false;


                    }
                }
                return Liste_Carte;
        }
        public static List<Transaction> ReadTrans(string path, List<Compte> Liste_Compte)
        {
            List<Transaction> Liste_Trans = new List<Transaction>();
            int readLen;
            string[] readin;
            // Datetime au format 13/09/2026 11:25:26
            string format = "dd/MM/yyyy HH :mm :ss";
            System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;

            List<int> liste_id = new List<int>();

            Transaction trtmp;
            int id;
            DateTime horodatage;
            double montant;
            int cpt_exp;
            int cpt_dest;

            bool id_ok = false ;
            bool horodatage_ok = true;
            bool montant_ok = false;
            bool cpt_exp_ok = false;
            bool cpt_dest_ok = false;

            using (FileStream fs = File.OpenRead(path))
            {
                //Méthode à revoir, implémenter / utiliser un readline , sinon ou troncature
                // Calculer nb byte exact ? sizeof? +1 ? \n
                byte[] b = new byte[1024];
                UTF8Encoding tempB = new UTF8Encoding(true);

                while ((readLen = fs.Read(b, 0, b.Length)) > 0)
                {
                    readin = tempB.GetString(b, 0, readLen).Split(';','\n');
                    for (int cpt = 0; cpt < readin.Length - 4; cpt += 5)
                    {
                        id_ok = int.TryParse(readin[cpt], out id);

                        if (id_ok && liste_id.Contains(id))
                        {
                            id_ok = false;
                        }

                        horodatage_ok = DateTime.TryParseExact(readin[cpt + 1], format,provider, System.Globalization.DateTimeStyles.AllowInnerWhite,out horodatage);
                       
                        montant_ok = double.TryParse(readin[cpt + 2], out montant);

                        if(montant_ok && montant > 0.0  )
                        {
                            montant_ok = true;
                        }
                        else
                        {
                            montant_ok = false;
                        }


                        cpt_exp_ok = int.TryParse(readin[cpt + 3], out cpt_exp);

                        //Si la liste des comptes ne possède pas le compte expéditeur, transaction invalide
                        if (!cpt_exp_ok || !( !(Liste_Compte.Where(compte => compte.ID == cpt_exp).Count() == 0) || cpt_exp == 0))
                        {
                            cpt_exp_ok = false;
                        }

                        cpt_dest_ok = int.TryParse(readin[cpt + 4], out cpt_dest);

                        //Si la liste des comptes ne possède pas le compte destinataire, transaction invalide, si 0, env
                        if (!cpt_dest_ok || !(!(Liste_Compte.Where(compte => compte.ID == cpt_dest).Count() == 0) || cpt_dest == 0))
                        {
                            cpt_dest_ok = false;
                        }

                        // Si tous les paramètres sont bons, on instance
                        if (id_ok && horodatage_ok && montant_ok && cpt_exp_ok && cpt_dest_ok)
                        {
                            trtmp = new Transaction(id, horodatage, montant, cpt_exp, cpt_dest);
                            Liste_Trans.Add(trtmp);
                            liste_id.Add(id); 

                        }


                        id_ok = false;
                        horodatage_ok = false;
                        montant_ok = false;
                        cpt_exp_ok = true;
                        cpt_dest_ok = true;
                    }

                    

                }
            }

        return Liste_Trans;
        }
        
        public static void WriteTrans(string path,int id, bool valid)
        {

            
        }

    }
}
