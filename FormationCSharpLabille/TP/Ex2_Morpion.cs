using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2
{
    public static class Morpion
    {
        

        public static void DisplayMorpion(char [,] TabMorp)
        {
            for(int i = 0; i < TabMorp.GetLength(0); i++)
            {
                for(int j = 0; j < TabMorp.GetLength(1); j++){
                    Console.Write(TabMorp[i, j]+" ");
                }
                Console.WriteLine("");
            }
            return;
        }

        public static int CheckMorpion(char[,] TabMorp)
        {
            for(int i = 0; i < TabMorp.GetLength(0); i++)
            {
                for (int j = 0; j < TabMorp.GetLength(1); j++)
                {
                    if(TabMorp[i,j] == '_')
                    {
                        return -1;

                    }

                }
            }
                              
            if ((TabMorp[0,0] == 'O' && TabMorp[0, 1] == 'O' && TabMorp[0, 2] == 'O' ||
                TabMorp[1, 0] == 'O' && TabMorp[1, 1] == 'O' && TabMorp[1, 2] == 'O' ||
                TabMorp[2, 0] == 'O' && TabMorp[2, 1] == 'O' && TabMorp[2, 2] == 'O' ||
                TabMorp[0, 0] == 'O' && TabMorp[1, 0] == 'O' && TabMorp[2, 0] == 'O' ||
                TabMorp[0, 1] == 'O' && TabMorp[1, 1] == 'O' && TabMorp[2, 1] == 'O' ||
                TabMorp[0, 2] == 'O' && TabMorp[1, 2] == 'O' && TabMorp[2, 2] == 'O' ||
                TabMorp[0, 0] == 'O' && TabMorp[1, 1] == 'O' && TabMorp[2, 2] == 'O' ||
                TabMorp[0, 2] == 'O' && TabMorp[1, 1] == 'O' && TabMorp[2, 0] == 'O' 
                ) )
            {
                return 2;
            }

            if ((TabMorp[0, 0] == 'X' && TabMorp[0, 1] == 'X' && TabMorp[0, 2] == 'X' ||
                TabMorp[1, 0] == 'X' && TabMorp[1, 1] == 'X' && TabMorp[1, 2] == 'X' ||
                TabMorp[2, 0] == 'X' && TabMorp[2, 1] == 'X' && TabMorp[2, 2] == 'X' ||
                TabMorp[0, 0] == 'X' && TabMorp[1, 0] == 'X' && TabMorp[2, 0] == 'X' ||
                TabMorp[0, 1] == 'X' && TabMorp[1, 1] == 'X' && TabMorp[2, 1] == 'X' ||
                TabMorp[0, 2] == 'X' && TabMorp[1, 2] == 'X' && TabMorp[2, 2] == 'X' ||
                TabMorp[0, 0] == 'X' && TabMorp[1, 1] == 'X' && TabMorp[2, 2] == 'X' ||
                TabMorp[0, 2] == 'X' && TabMorp[1, 1] == 'X' && TabMorp[2, 0] == 'X'
                ))
            {
                return 1;
            }
            return 0;
        }
    }
}
