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

             simpleIterationMethod_ForOneUnknown();
             simpleIterationMethod_ForTwoUnknown();

             nyutonMethod_ForOneUnknown();
             nyutonMethod_ForTwoUnknown();

            diff_One();
            diff_Two();

            Console.ReadLine();
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
                consoleWriteSecondFunction(x_new, count);

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

                consoleWrite(x_new, y_new, count);

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

            consoleWriteSecondFunction(x_old, count);

            while (true)
            {
                count++;
                x_new = x_old - (2 * x_old + Math.Log10(2 * x_old + 3) - 1) 
                    / (2 / (Math.Log(10) * (2 * x_old + 3)) + 2);

                consoleWriteSecondFunction(x_new, count);
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
            Vector<double> vector_old = DenseVector.OfArray(new double[]
            {
                x_old,y_old
            });
            Vector<double> vector_new;

            Console.WriteLine(matrixOf_Diff_F1_F2);
            Console.WriteLine(vectorOf_f1_f2);
  
            while (true)
            {
                    count++;
                    vector_new = vector_old - ( matrixOf_Diff_F1_F2.Inverse() * vector_f1_f2(vector_old[0],vector_old[1]) );

                    consoleWrite(vector_new[0], vector_new[1], count);

                if (Math.Abs(vector_old.Sum() - vector_new.Sum()) < 0.000001 || count == 1000) break;
                    vector_old = vector_new;
            }
        }

        static Vector<double> vector_f1_f2(double x, double y)
        {
            Vector<double> vectorOf_f1_f2 = DenseVector.OfArray(new double[]
            {
                3 * x - Math.Cos(y) - 0.9,
                Math.Sin( x - 0.6) - y - 1.6
            });
            return vectorOf_f1_f2;
        }

        /*  example for 
        *              f1 = 3 * x - cos y - 0.9 = 0
        *              f2 = sin( x - 0.6 ) - y - 1.6 = 0 
        *              Starting point (0;-1)   
        *              K1 = 1 K2 = 0.5 H = 0.01     
       */

        static void diff_One()
        {
            Console.WriteLine("**************** Diff One Method ****************\n\n");
            count = 0;
            x_old = 0;
            y_old = -1;
            double k1 = 1;
            double k2 = 0.5;
            double h = 0.01;
            Vector<double> vector_old = DenseVector.OfArray(new double[]
            {
                x_old,y_old
            });
            Vector<double> vector_new;

            while (true)
            {
                count++;
                vector_new = vector_old - h * vectorOf_Nabla_f1_f2(vector_old[0], vector_old[1]);

                if ( count % 100 == 0) 
                    consoleWrite(vector_new[0], vector_new[1], count);
                

                if (Math.Abs(vector_old.Sum() - vector_new.Sum()) < 0.000001 || count == 10000)
                {
                    consoleWrite(vector_new[0], vector_new[1], count);
                    break;
                }
                vector_old = vector_new;
            }
        }

        /*  example for 
         *         f1 = 3 * x - cos y - 0.9 = 0
         *         f2 = sin( x - 0.6 ) - y - 1.6 = 0 
         *         Starting point (0;-1)   
         *         K1 = 1 K2 = 0.5 H = 0.01  Gamma = 1  
        */
        static void diff_Two()
        {
            Console.WriteLine("**************** Diff Two Method ****************\n\n");
            count = 0;
            x_old = 0;
            y_old = -1;
            double k1 = 1;
            double k2 = 0.5;
            double h = 0.01;
            Vector<double> vector_old = DenseVector.OfArray(new double[]
            {
                x_old,y_old
            });
            Vector<double> vector_new;
            Vector<double> vector_old2 = DenseVector.OfArray(new double[]
           {
                x_old,y_old
           });
            double gamma = 1;

            vector_new = (1 / (2 + gamma * h)) * (4 * vector_old - 2 * Math.Pow(h, 2) * vectorOf_Nabla_f1_f2(vector_old[0], vector_old[1]));
            Console.WriteLine(vector_new);
            while (true)
            {
                count++;
                vector_new = (1 / (2 + gamma * h)) * (4 * vector_old - (2 - gamma * h) * vector_old2 - 2 * Math.Pow(h, 2) * vectorOf_Nabla_f1_f2(vector_old[0], vector_old[1]));
                vector_old2 = vector_old;

                if (count % 100 == 0)
                    consoleWrite(vector_new[0], vector_new[1], count);
                                
                if (Math.Abs(vector_old.Sum() - vector_new.Sum()) < 0.000001 || count == 10000){
                    consoleWrite(vector_new[0], vector_new[1], count);
                    break;
                }
                vector_old = vector_new;
            }
        }

        static Vector<double> vectorOf_Nabla_f1_f2(double x, double y)
        {
           Vector<double> vectorOf_Nabla_f1_f2 = DenseVector.OfArray(new double[]
           {
                18 * x - 6 * Math.Cos(y) - Math.Cos(x - 0.6) * (y - Math.Sin(x - 0.6) + 1.6) - 5.4,
                y - Math.Sin(x - 0.6) - 2 * Math.Sin(y) * (Math.Cos(y) - 3 * x + 0.9) + 1.6
           });
           return vectorOf_Nabla_f1_f2;
        }

        static void consoleWrite(double x1,double x2,int count)
        {
            Console.WriteLine("Iteration number = " + count);
            Console.WriteLine("X_New = {0:0.000000} \nY_New = {1:0.000000}", x1, x2);
            Console.WriteLine("F1(X_New,Y_New) = {0:0.000000}", 3 * x1 - Math.Cos(x2) - 0.9);
            Console.WriteLine("F2(X_New,Y_New) = {0:0.000000}", Math.Sin(x1 - 0.6) - x2 - 1.6);
            Console.WriteLine();
        }

        static void consoleWriteSecondFunction(double x1,int count)
        {
            Console.WriteLine("Iteration number = " + count);
            Console.WriteLine("X_New = {0:0.0000000}", x1);
            Console.WriteLine("F(x) = {0:0.0000000}", 2 * x1 + Math.Log10(2 * x1 + 3) - 1);
            Console.WriteLine();
        }
    }
}
