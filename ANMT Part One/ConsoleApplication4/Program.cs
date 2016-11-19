using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics;
using System.Diagnostics;

namespace ConsoleApplication4
{
    
    class Program
    {
     
        static int SIZE = 3;
        static int maximalIterationCount = 100;
        static void Main(string[] args)
        {
            int count = 0;
            Matrix<double> arrayForA = DenseMatrix.OfArray(new double[,]
            {
                {4,1,-1 },                //{0, 1, 3 },
                {1,2,0 },                //{5, -1,  1 },
                {-1,0,3 },              /// {2, -2, 2 },
            });
            Vector<double> arrayForB = DenseVector.OfArray(new double[]
            {
                7,0,-2                       ////0,0,1
            });
            Vector<double> oldVectorForX = DenseVector.OfArray(new double[]
            {
                0,0,0     ////-10,-10,10
            });

            Matrix<double> eye3 = DenseMatrix.OfArray(new double[,]
           {
                {1,0,0},
                {0,1,0},
                {0,0,1},
           });

            Matrix<double> c = DenseMatrix.OfArray(new double[,]
        {
                {0.5,0.1,0.1},
                {0.1,0.5,0},
                {0.1,0,0.5},
        });
          double tao = 0.1;


             NvazaguynQarakusineriMethod(count, arrayForA, arrayForB, oldVectorForX, eye3);

             ZeidelMethod(count, arrayForA, arrayForB, oldVectorForX, eye3);

             HasarakIterationMEthod(count, arrayForA, arrayForB, oldVectorForX, eye3, c);

             AnBacahaytMEthod(count, arrayForA, arrayForB, oldVectorForX, eye3, c, tao);

             BacahayMethod( count, arrayForA, arrayForB,  oldVectorForX);

            Console.Read();

        }



        private static void NvazaguynQarakusineriMethod(int count, Matrix<double> arrayForA, Vector<double> arrayForB, Vector<double> oldVectorForX, Matrix<double> eye3)
        {
            Console.WriteLine("\n\n*******************   Nvazaguyn-Qarakusineri-Method  *******************");
            count = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Vector<double> newVectorForX;
            Matrix<double> arrayForDV = DenseMatrix.Build.Dense(arrayForA.RowCount, arrayForA.ColumnCount);
            Matrix<double> arrayFor_At_And_A = arrayForA.Transpose() * arrayForA;
                      
            for (int i = 0; i < arrayForA.RowCount; i++)
                for (int j = 0; j < arrayForA.ColumnCount; j++)
                    if (i > j || i == j)
                        arrayForDV[i, j] = arrayFor_At_And_A[i, j];

            while (true)
            {
                count++;

                newVectorForX = (eye3 - arrayForDV.Inverse() * arrayForA.Transpose() * arrayForA) * oldVectorForX + (arrayForDV.Inverse() * arrayForA.Transpose() * arrayForB);

                if (count == maximalIterationCount || Math.Abs(oldVectorForX.Sum() - newVectorForX.Sum()) < 0.00001)
                {
                    Console.WriteLine("Iteration number count = {0} ", count);
                    Console.WriteLine(newVectorForX);
                    break;
                }

                if (count % 10 == 0)
                {
                    Console.WriteLine("Iteration number count = {0} ", count);
                    Console.WriteLine(newVectorForX);
                }

                oldVectorForX = newVectorForX;
            }

            stopWatch.Start();
            TimeSpan ts = stopWatch.Elapsed;
            string elaspedTIme = String.Format("{0:00}.{1:00}", ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("Nvazaguyn-Qarakusineri-Method RunTime: {0}", elaspedTIme);
        }

        private static void ZeidelMethod(int count, Matrix<double> arrayForA, Vector<double> arrayForB, Vector<double> oldVectorForX, Matrix<double> eye3)
        {
            Console.WriteLine("\n\n*******************   Zeidel-Method  *******************");
            count = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Vector<double> newVectorForX;
            Matrix<double> arrayForDV = DenseMatrix.Build.Dense(arrayForA.RowCount, arrayForA.ColumnCount);
            Matrix<double> arrayforU = DenseMatrix.Build.Dense(arrayForA.RowCount, arrayForA.ColumnCount);

            for (int i = 0; i < arrayForA.RowCount; i++)
            {
                for (int j = 0; j < arrayForA.ColumnCount; j++)
                {
                    if (i > j || i == j)
                    {
                        arrayForDV[i, j] = arrayForA[i,j];
                    }

                    else if ( i < j)
                    {
                        arrayforU[i,j] = arrayForA[i, j];
                    }
                }
            }
            Console.WriteLine(arrayForDV);
            Console.WriteLine(arrayforU);

            while (true)
            {
                count++;

                newVectorForX = (eye3 - arrayForDV.Inverse() * arrayForA) * oldVectorForX + (arrayForDV.Inverse() * arrayForB);

                if (count == maximalIterationCount || Math.Abs(oldVectorForX.Sum() - newVectorForX.Sum()) < 0.00001)
                {
                    Console.WriteLine("Iteration number count = {0} ", count);
                    Console.WriteLine(newVectorForX);
                    break;
                }

               if (count % 10 == 0)
                {
                    Console.WriteLine("Iteration number count = {0} ", count);
                    Console.WriteLine(newVectorForX);
                }

                oldVectorForX = newVectorForX;
            }


            stopWatch.Start();
            TimeSpan ts = stopWatch.Elapsed;
            string elaspedTIme = String.Format("{0:00}.{1:00}", ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("Zeidel-Method RunTime: {0}", elaspedTIme);
        }

        private static void HasarakIterationMEthod(int count, Matrix<double> arrayForA, Vector<double> arrayForB, Vector<double> oldVectorForX, Matrix<double> eye3, Matrix<double> c)
        {
            Console.WriteLine("\n\n*******************   Hasarak-Iteration-Method  *******************");

            count = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
        
            Vector<double> newVectorForX;
            Matrix<double> d = DenseMatrix.Build.DenseOfMatrix(c);
            

               for (int i = 0; i < c.RowCount; i++)
                {
                    for (int j = 0; j < c.ColumnCount; j++)
                    {
                        if (i != j)
                        {
                            d[i, j] = 0;
                        }
                    }
                }

            while (true)
            {
                count++;

                newVectorForX = (eye3 - d.Inverse() * arrayForA) * oldVectorForX + d.Inverse() * arrayForB;

                if (count == maximalIterationCount || Math.Abs(oldVectorForX.Sum() - newVectorForX.Sum()) < 0.00001)
                {
                    Console.WriteLine("Iteration number count = {0} ", count);
                    Console.WriteLine(newVectorForX);
                    break;
                }

                if (count % 10 == 0)
                {
                    Console.WriteLine("Iteration number count = {0} ", count);
                    Console.WriteLine(newVectorForX);
                }

                oldVectorForX = newVectorForX;
            }
                       
            stopWatch.Start();
            TimeSpan ts = stopWatch.Elapsed;
            string elaspedTIme = String.Format("{0:00}.{1:00}", ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("Hasarak Method RunTime: {0}", elaspedTIme);
        }


        private static void AnBacahaytMEthod( int count, Matrix<double> arrayForA, Vector<double> arrayForB,  Vector<double> oldVectorForX,  Matrix<double> eye3, Matrix<double> c, double tao)
        {
            Console.WriteLine("\n\n*******************   An-Bacahayt-Method  *******************");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            count = 0;
            ////anbacahayt
            Matrix<double> arrayForM = (2 * c) - tao * arrayForA;
            Console.WriteLine(arrayForM);
            Evd<double> eigenM = arrayForM.Evd();
            Vector<Complex> eigenVectroM = eigenM.EigenValues;           

            if (eigenVectroM.All(item => item.Real > 0))
            {
                Console.WriteLine(eigenVectroM);
                Vector<double> newVectorForX;
                while (true)
                {
                    count++;
                    newVectorForX = (eye3 - tao * c.Inverse() * arrayForA) * oldVectorForX + (tao * c.Inverse() * arrayForB);


                    if (count == maximalIterationCount || Math.Abs(oldVectorForX.Sum() - newVectorForX.Sum()) < 0.00001)
                    {
                        Console.WriteLine("Iteration number count = {0} ", count);
                        Console.WriteLine(newVectorForX);
                        break;
                    }

                    if (count % 10 == 0)
                    {
                        Console.WriteLine("Iteration number count = {0} ", count);
                        Console.WriteLine(newVectorForX);
                    }
                    oldVectorForX = newVectorForX;
                }
            }
            else Console.WriteLine("M matrxi EIG  is a NEGATIVE");

            stopWatch.Start();
            TimeSpan ts = stopWatch.Elapsed;
            string elaspedTIme = String.Format("{0:00}.{1:00}", ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("AnBacahayt Method RunTime: {0}", elaspedTIme);

        }

        private static void BacahayMethod( int count, Matrix<double> arrayForA, Vector<double> arrayForB,  Vector<double> oldVectorForX)
        {
            Console.WriteLine("\n\n*******************   Bacahayt-Method  *******************");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Vector<double> newVectorForX;

            while (true) /// bacahayt
            {
                count++;
                newVectorForX = (arrayForA * oldVectorForX) + arrayForB;

               

                if (count == maximalIterationCount || Math.Abs(oldVectorForX.Sum() - newVectorForX.Sum()) < 0.00001)
                {
                    Console.WriteLine("Iteration number count = {0} ", count);
                    Console.WriteLine(newVectorForX);
                    break;
                }

                if (count % 10 == 0)
                {
                    Console.WriteLine("Iteration number count = {0} ", count);
                    Console.WriteLine(newVectorForX);
                }

                oldVectorForX = newVectorForX;
            }

            stopWatch.Start();
            TimeSpan ts = stopWatch.Elapsed;
            string elaspedTIme = String.Format("{0:00}.{1:00}", ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("Bacahayt Method RunTime: {0}", elaspedTIme);
        }

    }
}
