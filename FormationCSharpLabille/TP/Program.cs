using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    class Program
    {
        enum sdsf : Byte {
            } 



        static void Main(string[] args)
        {

            ElementaryOperations.BasicOperation(12, 5, '+');
            ElementaryOperations.IntegerDivision(12, 5);
            ElementaryOperations.Pow(2, 3);
            SpeakingClock.GoodDay(15);
            Pyramid.PyramidConstruction(5, false);
            Console.WriteLine(Factorial.Factorial_(2));
            Console.WriteLine(Factorial.FactorialRecursive(5));

            Console.ReadKey();
        }
    }
}
