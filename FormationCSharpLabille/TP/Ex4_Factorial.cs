using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public static class Factorial
    {
        public static int Factorial_(int n)
        {
            int RetVal = 1;

            if(n > 1)
            {
                for(int i = 2;  i <= n;  i++)
                {
                    RetVal *= i;
                }
            }
           
            return RetVal;
        }

        public static int FactorialRecursive(int n)
        {
             if ( n <= 1)
            {
                return 1;
            }
            return n * FactorialRecursive(n - 1);
            
        }
    }
}
