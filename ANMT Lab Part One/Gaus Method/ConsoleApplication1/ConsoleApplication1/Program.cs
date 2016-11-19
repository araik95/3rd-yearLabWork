using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            uint SIZE_OF_VARIABLES = 0;
            uint SIZE_OF_LINE = 0;
            ConsoleColor pref = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Gauss Method");
            Console.ForegroundColor = pref;

            Console.Write("\nWrite Size Of Variables = ");
            string ss = Console.ReadLine();
            SIZE_OF_VARIABLES = uint.Parse(ss);
            Console.Write("Write Size Of Lines = ");
            ss = Console.ReadLine();
            SIZE_OF_LINE = uint.Parse(ss);

            Console.WriteLine();
            GausMethod ob = new GausMethod(SIZE_OF_LINE,SIZE_OF_VARIABLES);
            
            for (int i = 0; i < ob.Matrix.Count(); i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                for (int j = 0; j < ob.Matrix.Count(); j++)
                {
                    Console.Write("A[{0}][{1}] = ",i+1,j+1);
                    ss = Console.ReadLine();
                    ob.Matrix[i][j] = double.Parse(ss);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nB[{0}] = ",i+1);
                ss = Console.ReadLine();
                ob.RightPart[i] = double.Parse(ss);
            }
     
            ob.SolveMatrix();

            var s = ob.ToString();
            Console.WriteLine(s);

            Console.ReadKey();
        }
    }
}
