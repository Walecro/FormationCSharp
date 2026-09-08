using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2
{
    public static class Matrice
    {
        public static int[,] BuildingMatrix(int[] LeftV, int[] RightV)
        {
            int[,] RetMat = new int[LeftV.Length, RightV.Length];

            for (int i = 0; i < LeftV.Length; i++)
            {
                for (int j = 0; j < RightV.Length; j++)
                {
                    RetMat[i, j] = LeftV[i] * RightV[j];
                }
            }


            return RetMat;
        }

        public static void DisplayMatrix(int[,] M)
        {
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }

        public static int[,] Addition(int[,] M1, int[,] M2)
        {
            int[,] RetMat = new int[M1.GetLength(0), M1.GetLength(1)];

            if(M1.GetLength(1) != M2.GetLength(1) || M1.GetLength(0) != M2.GetLength(0))
            {
                Console.WriteLine("Tailles invalides");
                return null;

            }

            for(int i = 0; i < M1.GetLength(0); i++)
            {
                for(int j = 0; j < M1.GetLength(1); j++)
                {
                    RetMat[i, j] = M1[i, j] + M2[i, j];
                }
            }
            return RetMat;
        }

        public static int[,] Substraction(int[,] M1, int[,] M2)
        {
            int[,] RetMat = new int[M1.GetLength(0), M1.GetLength(1)];

            if (M1.GetLength(1) != M2.GetLength(1) || M1.GetLength(0) != M2.GetLength(0))
            {
                Console.WriteLine("Tailles invalides");
                return null;

            }

            for (int i = 0; i < M1.GetLength(0); i++)
            {
                for (int j = 0; j < M1.GetLength(1); j++)
                {
                    RetMat[i, j] = M1[i, j] - M2[i, j];
                }
            }
            return RetMat;
        }

        public static int[,] Multiplication(int[,] M1 , int[,] M2)
        {
            int[,] MatMul = new int[M1.GetLength(0), M2.GetLength(1)];
            if(M1.GetLength(0) != M2.GetLength(1))
            {
                Console.WriteLine("Dimensions invalides pour une multiplication"+ M1.GetLength(0) + " " + M2.GetLength(1)  );
                return null;

            }

            for (int i = 0; i < M1.GetLength(0); i++)
            {
                for (int j = 0; j < M2.GetLength(1); j++)
                {
                    for (int k = 0; k < M1.GetLength(1); k++)
                    {
                        MatMul[i, j] += M1[i, k] * M2[k, j];
                    }
                }
            }

            return MatMul;
        }
    }
}