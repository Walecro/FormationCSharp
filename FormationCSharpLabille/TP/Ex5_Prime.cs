using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public static class Prime
    {
        public static bool IsPrime(int n)
        {
            bool Prime = true;
            for(int i = 2; i <= Math.Sqrt(n); i++)
            {
                if(n % i == 0)
                {
                    Prime = false;
                    break;
                }
            }
            return Prime;
        }

        public static void DisplayPrimes()
        {
            for(int i = 2; i < 100; i++)
            {
                if (IsPrime(i)){
                    Console.WriteLine(i);
                }
            }
        }
    }
}
