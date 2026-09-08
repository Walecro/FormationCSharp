using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serie2;

namespace TP
{
    class Program
    {
      
        static void Main(string[] args)
        {
            //Test_SerieI();
            //Test_SerieII();
            //Test_SerieIAnnexe();
            Test_SerieIIAnnexe();

            Console.ReadKey();
        }

        static void Test_SerieI()
        {
            /*ElementaryOperations.BasicOperation(12, 5, '+');
            ElementaryOperations.IntegerDivision(12, 5);
            ElementaryOperations.Pow(2, 3);
            SpeakingClock.GoodDay(15);
            Pyramid.PyramidConstruction(5, false);
            Console.WriteLine(Factorial.Factorial_(2));
            Console.WriteLine(Factorial.FactorialRecursive(5));
            */

            
        }
        static void Test_SerieII()
        {

            int[] t = { 7, 9, 1, 2 ,1,3,88,77,99,66,44,22,55,11,995 };
            /*
            int[] t2 = { 3, 7, 52, 88 };
            TasksTables.SumTab(t);
            TasksTables.OpeTab(t, '+', 2);
            TasksTables.ConcatTab(t, t2);
            */
            /*
            char[,] TabMorp = { { 'X', 'O', 'O' }, { 'X', 'O', 'X' }, { 'X', 'X', 'O' } };
            Morpion.DisplayMorpion(TabMorp);
            Console.WriteLine(Morpion.CheckMorpion(TabMorp));

            char[,] TabMorp2 = { { '_', 'O', 'O' }, { 'X', 'O', 'X' }, { 'X', 'X', 'O' } };
            Morpion.DisplayMorpion(TabMorp2);
            Console.WriteLine(Morpion.CheckMorpion(TabMorp2));


            char[,] TabMorp3 = { { 'X', 'O', 'X' },
                                 { 'X', 'O', 'O' },
                                 { 'O', 'X', 'X' } };
            Morpion.DisplayMorpion(TabMorp3);
            Console.WriteLine(Morpion.CheckMorpion(TabMorp3));
            */
            /*
            Console.WriteLine(Search.LinearSearch(t, 2));
            Console.WriteLine(Search.LinearSearch(t, 99));
            */
            Array.Sort(t);
            for(int i = 0; i < t.Length; i++)
            {
                Console.Write(t[i]+" ");
            }
            Console.WriteLine();
            Console.WriteLine(Search.BinarySearch(t, 98));
            Console.WriteLine(Search.BinarySearch(t, 99));
        }

        static void Test_SerieIAnnexe()
        {

            //Prime.DisplayPrimes();
            Euclide.Gcd(100, 20);
            Euclide.Gcd(121, 4);
            Euclide.Gcd(4, 7);



        }

        static void Test_SerieIIAnnexe()
        {
            /*
            int[] LV = { 7, 9, 2, 5 };
            int[] RV = { 3, 7, 4 };
            int[,] MRet;
            int[,] M = Matrice.BuildingMatrix(LV, RV);
            int[,] M2 = Matrice.BuildingMatrix(RV, LV);

            int[,] t1 = { { 1, 2 }, 
                          { 3, 4 } };
            //Matrice.DisplayMatrix(M);
            
            MRet = Matrice.Addition(M, M);
            Matrice.DisplayMatrix(MRet);

            MRet = Matrice.Substraction(M, M);
            Matrice.DisplayMatrix(MRet);
            
            
            MRet = Matrice.Multiplication(t1, t1);
            Matrice.DisplayMatrix(MRet);*/
            /*
            int[] Era = Eratos.EratostenesSieve(100);

            for ( int i = 0; i < Era.Length; i++)
            {
                Console.Write(Era[i] + " ");
            }
            */
            /*
            QCM Q = new QCM();
            Console.WriteLine(Q.AskQuestion(Q));*/

            QCM[] QTab = new QCM[3];
            QTab[0] = new QCM(); QTab[1] = new QCM();
            QTab[2] = new QCM();


            int pts = QCM.AskQuestions(QTab);

            
        }
    }
}
