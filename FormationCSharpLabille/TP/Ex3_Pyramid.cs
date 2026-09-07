using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public static class Pyramid
    {
        public static void PyramidConstruction(int n, bool isSmooth)
        {
            int nbl = 1;

            if (isSmooth)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = n - i; j > 0; j--)
                    {
                        Console.Write(" ");
                    }

                    for (int j = 0; j < nbl; j++)
                    {
                        Console.Write("+");
                    }
                    nbl += 2;


                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = n - i; j > 0; j--)
                    {
                        Console.Write(" ");
                    }
                    if( i % 2 == 0)
                    {
                        for (int j = 0; j < nbl; j++)
                        {
                            Console.Write("+");
                        }
                    }
                    else
                    {
                        for (int j = 0; j < nbl; j++)
                        {
                            Console.Write("-");
                        }
                    }
                    
                    nbl += 2;


                    Console.WriteLine();
                }
            }
           
        }
    }
}
