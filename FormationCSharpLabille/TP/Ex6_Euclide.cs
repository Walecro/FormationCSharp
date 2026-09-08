using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public static class Euclide
    {
        public static int Gcd(int a,int b)
        {
            int q, r;
            int tmp;
            Console.Write("Le PGCD de " + a + " et de " + b + " est : ");
            if ( a < b)
            {
                tmp = a;
                a = b;
                b = tmp;
            }
            q = a / b;
            r = a % b;
            while (r != 0)
            {
                a = b;
                b = r;

                q = a / b;
                r = a % b;
            }
            Console.WriteLine(b);
            return b    ;
        }

    }
}
