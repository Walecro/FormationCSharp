using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2
{
    public static class Search
    {
        public static int LinearSearch(int[] tableau, int valeur)
        {
            int RetVal = -1;
            for(int i = 0; i < tableau.Length; i++)
            {
                if(tableau[i] == valeur)
                {
                    RetVal = i;
                    break;
                }
            }
          
            return RetVal;
        }

        public static int BinarySearch(int[] tableau, int valeur)
        {

            int fin, deb;
            int i;
            int RetVal = -1;

            deb = 0;
            fin = tableau.Length - 1;
            while(RetVal ==  -1 && fin != deb)
            {
                i = deb + (fin - deb) / 2;
                if(tableau[i] == valeur)
                {
                    RetVal = i;
                }
                else if (tableau[i] > valeur)
                {
                    fin = i - 1;
                }
                else
                {
                    
                    deb = i;
                }
                

            }
            return RetVal;
        }
    }
}
