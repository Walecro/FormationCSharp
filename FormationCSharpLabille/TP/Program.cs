using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    class Program
    {
        enum PolitiqueNonPedophile : Byte {
            } 



        static void Main(string[] args)
        {
           
            Console.OutputEncoding = Encoding.Unicode;
            // Pour les euros €€€€€€€€€€€€
            bool OK = int.TryParse(Console.ReadLine(),out int x);

            if (OK)
            {
                Console.Write(x);
            }
            else
            {
                Console.WriteLine("Pas de chance lol");
            }

            Console.ReadKey();
        }
    }
}
