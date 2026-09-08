using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2
{
    public static class Eratos
    {
        public static int[] EratostenesSieve(int n)
        {
            int[] Linteger = Enumerable.Range(2, n - 2).ToArray();
            List<int> LPrime = Enumerable.Range(2, n-2 ).ToList();
            int Lindex = 0;
            int curInteger = Linteger[Lindex];
            int MaxInteger = Linteger[Linteger.Length-1];

            while(curInteger < Math.Sqrt(MaxInteger))
            {
                for( int i = Lindex+1; i < Linteger.Length; i++)
                {
                    if( Linteger[i]%curInteger == 0)
                    {
                        LPrime.Remove(Linteger[i]);
                    }
                }
                //MaxInteger = Linteger[Linteger.Length - 1];
                Lindex++;
                curInteger = Linteger[Lindex];
            }
            
            return LPrime.ToArray();
        }

    }
}
