using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;


namespace LabTwo
{
    class Program
    {

        static int count;
        static double x_new, x_old;
        static double y_new, y_old;

        static void Main(string[] args)
        {
            //simpleIterationMethod_ForTwoUnknown();
            //simpleIterationMethod_V1(); 
            //nyutonMethod_V1(); 
            nyutonMethod_ForTwoUnknown();
        }

        /*   example for 
        *              f = 2 * x + log(2 * x + 3) - 1
        *              Starting point (0)        
        */
        static void simpleIterationMethod_ForOneUnknown()
        {
            Console.WriteLine("**************** Simple Iteration Method ForOneUnknown ****************\n\n");           
            x_old = 0;
            count = 0;
            while (true)
            {           
                count++;
                x_new = (1 - Math.Log10(2 * x_old + 3)) / 2;
                Console.WriteLine("Iteration number = " + count);
                Console.WriteLine("X_New = {0:0.0000}",x_new);
                Console.WriteLine("F(x) = {0:0.0000}", 2 * x_new + Math.Log10(2 * x_new + 3) - 1);
                Console.WriteLine();

                if (Math.Abs(x_old - x_new) < 0.000001 || count == 1000) break;
                x_old = x_new;
            }
        }

        /*  example for 
         *              f1 = 3 * x - cos y - 0.9 = 0
         *              f2 = sin( x - 0.6 ) - y - 1.6 = 0 
         *              Starting point (-1;-1) 
        */
        static void simpleIterationMethod_ForTwoUnknown()
        {
            Console.WriteLine("**************** Simple Iteration Method For Two Unknown ****************\n\n");
         
            x_old = -1;
            y_old = -1;
            count = 0;
            while (true)
            {             
                count++;
                x_new = (Math.Cos(y_old) / 3) + 0.3;
                y_new = Math.Sin(x_old - 0.6) - 1.6;

                Console.WriteLine("Iteration number = " + count);
                Console.WriteLine("X_New = {0:0.0000}", x_new);
                Console.WriteLine("Y_New = {0:0.0000}", y_new);
                Console.WriteLine("F1(X_New,Y_New) = {0:0.0000}", 3 * x_new - Math.Cos(y_new) - 0.9 );
                Console.WriteLine("F2(X_New,Y_New) = {0:0.0000}", Math.Sin( x_new - 0.6) - y_new - 1.6);
                Console.WriteLine();

                if (Math.Abs(x_old - x_new) < 0.000001 || count == 1000) break;
                x_old = x_new;
                y_old = y_new;
            }
        }

       /*   example for 
       *              f = 2 * x + log(2 * x + 3) - 1
       *              Starting point (0.5)        
      */
        static void nyutonMethod_ForOneUnknown()
        {
            Console.WriteLine("**************** Nyuton Method ForOneUnknown ****************\n\n");

            double x0 = 0.5;
            x_old = x0;
            count = 0;

            Console.WriteLine("Iteration number = " + count);
            Console.WriteLine("X_New = {0:0.0000}", x_old);
            Console.WriteLine("F(x) = {0:0.0000}", 2 * x_old + Math.Log10(2 * x_old + 3) - 1);
            Console.WriteLine();

            while (true)
            {
                count++;
                x_new = x_old - (2 * x_old + Math.Log10(2 * x_old + 3) - 1) 
                    / (2 / (Math.Log(10) * (2 * x0 + 3)) + 2);

                Console.WriteLine("Iteration number = " + count);
                Console.WriteLine("X_New = {0:0.0000000}", x_new);
                Console.WriteLine("F(x) = {0:0.0000}",  2 * x_new + Math.Log10(2 * x_new + 3) - 1 );
                Console.WriteLine();

                if (Math.Abs(x_old - x_new) < 0.000001 || count == 1000) break;
                x_old = x_new;
            }
        }


        /*  example for 
         *              f1 = 3 * x - cos y - 0.9 = 0
         *              f2 = sin( x - 0.6 ) - y - 1.6 = 0 
         *              Starting point (2;1)        
        */
        static void nyutonMethod_ForTwoUnknown()
        {
            Console.WriteLine("**************** Nyuton Method For Two Unknown ****************\n\n");

            x_old = 2;
            y_old = 1;
            count = 0;

            Matrix<double> matrixOf_Diff_F1_F2 = DenseMatrix.OfArray(new double[,]
            {
                {3, Math.Sin(y_old) },
                {Math.Cos(x_old - 0.6 ), -1 }
            });
            Vector<double> vectorOf_f1_f2 = vector_f1_f2(x_old, y_old);
            Vector<double> matrix_old = DenseVector.OfArray(new double[]
            {
                x_old,y_old
            });
            Vector<double> matrix_new;

            Console.WriteLine(matrixOf_Diff_F1_F2);
            Console.WriteLine(vectorOf_f1_f2);
  
            while (true)
            {
                    count++;
                    matrix_new = matrix_old - ( matrixOf_Diff_F1_F2.Inverse() * vector_f1_f2(matrix_old[0],matrix_old[1]) ); 

                    Console.WriteLine("Iteration number = " + count);
                    Console.WriteLine("X_New = {0:0.0000} \nY_New = {1:0.0000}", matrix_new[0],matrix_new[1]);

                    Console.WriteLine("F1(X_New,Y_New) = {0:0.0000}", 3 * matrix_new[0] - Math.Cos(matrix_new[1]) - 0.9);
                    Console.WriteLine("F2(X_New,Y_New) = {0:0.0000}", Math.Sin(matrix_new[0] - 0.6) - matrix_new[1] - 1.6);
                    Console.WriteLine();

                    if (Math.Abs(matrix_old.Sum() - matrix_new.Sum()) < 0.000001 || count == 1000) break;
                    matrix_old = matrix_new;
            }
        }

        static Vector<double> vector_f1_f2(double x, double y)
        {
            Vector<double> vectorOf_f1_f2 = DenseVector.OfArray(new double[]
            {
                3 * x - Math.Cos(y) - 0.9,
                Math.Sin( x -0.6) - y - 1.6
            });
            return vectorOf_f1_f2;
        }
    }
}
