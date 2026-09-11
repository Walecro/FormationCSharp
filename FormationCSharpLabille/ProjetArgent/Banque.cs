using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArgent
{
    public class Banque
    {

        public static void Main(string[] args)
        {
            
            System.IO.Directory.SetCurrentDirectory(@"C:\Users\Formation\source\repos\CSharpLabille\FormationCSharpLabille\ProjetArgent");
            List<Carte> car_l = EntreeSortie.ReadCarte("cartes.csv");

            foreach (Carte c in car_l)
            {
                Console.WriteLine(c.ToString());
            }
            List<Compte> cpt_l = EntreeSortie.ReadCompte("compte.csv", car_l);

            foreach (Compte c in cpt_l)
            {
                Console.WriteLine(c.ToString());
            }

            List<Transaction> trs_l = EntreeSortie.ReadTrans("compte.csv", cpt_l);

            foreach (Transaction t in trs_l)
            {
                Console.WriteLine(t.ToString());
            }


            Console.ReadKey();
        }
    }
}
