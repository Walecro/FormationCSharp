using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2
{
    public static class TasksTables
    {
        public static int SumTab(int[] tab)
        {
            int RetVal = 0;
            int i;
            Console.WriteLine("Somme des éléments d'un tableau :");
            Console.Write("tab : [");
            if (tab.Length == 0)
            {
                return -1;
            }

            for (i = 0; i < tab.Length; i++)
            {
               
               Console.Write(tab[i] + ", ");
                RetVal += tab[i];
            }
            Console.WriteLine("]");

            Console.WriteLine("Somme : " + RetVal);
            return RetVal;
        }

        public static int[] OpeTab(int[] tab, char ope, int b)
        {

            Console.WriteLine("Opération sur un tableau :");
            Console.Write("tab : [");
            int i;
            if (tab.Length == 0)
            {
                return new int[0]; 
            }

            switch (ope)
            {
                case '+':
                    for ( i = 0; i < tab.Length; i++)
                    {
                        Console.Write(tab[i] + ", ");
                        tab[i] += b;
                    }
                    break;

                case '-':
                    for ( i = 0; i < tab.Length; i++)
                    {
                        Console.Write(tab[i] + ", ");
                        tab[i] -= b;
                    }
                    break;

                case '*':
                    for ( i = 0; i < tab.Length; i++)
                    {
                        Console.Write(tab[i] + ", ");
                        tab[i] *= b;
                    }
                    break;
                default:
                    return new int[0];

            }
            Console.WriteLine("] ");
            Console.WriteLine("ope : " + ope + " " + b);

            Console.Write("res : [");
            for (i = 0; i < tab.Length; i++)
            {
                Console.Write(tab[i] + ", ");
            }
            Console.WriteLine("] ");

            return tab;
        }

        public static int[] ConcatTab(int[] tab1, int[] tab2)
        {
            int i;
            int tLength = tab1.Length + tab2.Length;
            int[] tab = new int[tLength];
            Console.WriteLine("Concaténation de deux tableaux : ");
            Console.Write("tab 1 : [");
            for(i = 0; i < tab1.Length; i++)
            {
                tab[i] = tab1[i];
                Console.Write(tab1[i]+ ", ");
            }
            Console.WriteLine("]");
            for(int j = i; j < tLength; j++)
            {
                tab[j] = tab2[j - tab2.Length];
                Console.Write(tab2[j - tab2.Length] + ", ");

            }
            Console.WriteLine("]");

            Console.Write("tab 1 + tab 2 : [");
            for (int j = 0; j < tLength; j++)
            {
                Console.Write(tab[j] + ", ");
            }
            Console.WriteLine("] ");

            return tab;
        }
    }
}
