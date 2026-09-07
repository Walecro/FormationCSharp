        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public static class ElementaryOperations
    {
        public static void BasicOperation(int a, int b, char operation)
        {
            Console.Write(a.ToString() + operation + b.ToString() + "=");
            switch (operation) {

                case '+':
                    Console.WriteLine(a + b);
                    break;

                case '-':
                    Console.WriteLine(a - b);

                    break;
                case '*':
                    Console.WriteLine(a * b);

                    break;
                case '/':
                    Console.WriteLine(a / b);

                    break;

                default:
                    Console.WriteLine("Opération invalide");
                    break;
            }
        }

        public static void IntegerDivision(int a, int b)
        {
            if (b != 0){
                Console.WriteLine(a.ToString() + " = " + (a / b).ToString() + " * " + b + " + " + a % b);
            }
            else
            {
                Console.WriteLine(a.ToString() + " : " + b.ToString() + " Division par zéro Verboten");
            }
            
        }

        public static void Pow(int a, int b)
        {
            int r = 1;
            if (b >= 0)
            {
                for(int i = 1; i < b; i++)
                {
                    r = r * a;
                }
                Console.WriteLine(a.ToString() + " ^ " + b.ToString() + " = " + r.ToString());
            }
            else
            {
                Console.WriteLine("Opération invalide");
            }
        }
    }
}
