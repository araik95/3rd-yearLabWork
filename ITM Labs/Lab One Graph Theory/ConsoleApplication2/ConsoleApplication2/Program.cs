using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 18; ///// Matrix size
                           //int[,] array = new int[,] {                    /*0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 */
                           //                                  /*0*/         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                           //                                  /*1*/         {0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0 },
                           //                                  /*2*/         {0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0 },
                           //                                  /*3*/         {0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0 },
                           //                                  /*4*/         {0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0 },
                           //                                  /*5*/         {0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0 },
                           //                                  /*6*/         {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                           //                                  /*7*/         {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                           //                                  /*8*/         {0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0 },
                           //                                  /*9*/         {0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0 },
                           //                                 /*10*/         {0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0 },
                           //                                 /*11*/         {0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0 },
                           //                                 /*12*/         {0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0 },
                           //                                 /*13*/         {0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                           //                                 /*14*/         {0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0 },
                           //                                 /*15*/         {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0 },
                           //                                 /*16*/         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                           //                                 /*17*/         {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                           //                                 /*18*/         {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },

            //               };
            //int[,] array = new int[,] {                    /*0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 */
            //                                  /*0*/         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //                                  /*1*/         {0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0 },
            //                                  /*2*/         {0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0 },
            //                                  /*3*/         {0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0 },
            //                                  /*4*/         {0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0 },
            //                                  /*5*/         {0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0 },
            //                                  /*6*/         {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //                                  /*7*/         {1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0 },
            //                                  /*8*/         {0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0 },
            //                                  /*9*/         {0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0 },
            //                                 /*10*/         {0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0 },
            //                                 /*11*/         {0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0 },
            //                                 /*12*/         {0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0 },
            //                                 /*13*/         {0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //                                 /*14*/         {0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0 },
            //                                 /*15*/         {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0 },
            //                                 /*16*/         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            //                                 /*17*/         {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            //                                 /*18*/         {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //};
            //int[,] array = new int[,] {     /*0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8*/
            //                   /*0*/         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //                   /*1*/         {0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //                   /*2*/         {0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0 },
            //                   /*3*/         {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //                   /*4*/         {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0 },
            //                   /*5*/         {0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0 },
            //                   /*6*/         {0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0 },
            //                   /*7*/         {0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0 },
            //                   /*8*/         {0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0 },
            //                   /*9*/         {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0 },
            //                  /*10*/         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0 },
            //                  /*11*/         {0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0 },
            //                  /*12*/         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0 },
            //                  /*13*/         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0 },
            //                  /*14*/         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            //                  /*15*/         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0 },
            //                  /*16*/         {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0 },
            //                  /*17*/         {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            //                  /*18*/         {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //};

            int[,] array = new int[,]
            {
                {0,0,0,0,0,0,0 },
                {0,0,0,1,0,0,0 },
                {0,0,0,0,1,0,0 },
                {0,0,0,0,1,1,0 },
                {0,0,0,0,0,1,1 },
                {1,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0 }
            };

            printArray(array); /// Print default array
            int[,] array2 = new int[size, size];
            array2 = array;
            int count = 0;
            int exitGraph = 0;
            double R = 0;
            int T_6 = 0;
            /*Calculate T_1*/
            int T_1 = countOfStartGraph_T1(array);
            /*Calculate T_2 */
            int T_2 = countOfInsideGrapg_T2(array, T_1, out T_6, out exitGraph);

            int T_3 = countOfExitGraph_T3(array);
            double T_4 = 0;
            int T_5 = countOf_T5(array, T_1, exitGraph, out R);
            double T_7 = 0;
            string T_4String = "";
            string T_7String = "";
            string KmoString = "";
            double Kmo = 0;

            ConsoleColor pref = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nT1 = {0}", T_1);
            Console.WriteLine("T2 = {0}", T_2);
            Console.WriteLine("T3 = {0}", T_3);
            Console.WriteLine("T5 = {0}", T_5);
            Console.WriteLine("T6 = {0}", T_6);

            List<int[,]> sums = new List<int[,]>();
            sums.Add(array);
            while (true) /*Calculate T4 T7 and Kmo */
            {
                count++;
                T_4 = countOfT4InEveryIteration_T4(array2);
                T_7 = T_4 / count;
                Kmo = T_7 / T_4;
                T_4String += T_4.ToString() + "  ";
                T_7String += T_7.ToString() + "  ";
                KmoString += Kmo.ToString() + "  ";

                array2 = Multiplication(array, array2);
                if (sumArray(array2) == 0) break;
                sums.Add(array2);
            }

            Console.WriteLine("T4 = {0} ", T_4String);
            Console.WriteLine("T7 = {0}", T_7String);
            Console.ForegroundColor = pref;
            Console.ForegroundColor = ConsoleColor.Yellow;
            double Knk = T_5 / R;
            double tt = T_5;
            double dT2 = T_2; double dT6 = T_6; double dT3 = T_3;
            double Km = dT2 / (array.GetLength(0) - 1);
            Console.WriteLine("\nKm = {0:0.00} \nKnk = {1:0.00}\nKkrk = {2:0.00},\nKmo = {3:0.00}",
                Km,
                tt / R,
                (2 * dT6) / (dT3 * (dT3 - 1)),
                KmoString
                );
            printAllArrays(pref, sums);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Graf's Delta");
            Console.ForegroundColor = pref;
            printArray(AddTwoArray(sums));
            Console.ReadKey();
        }

        private static void printAllArrays(ConsoleColor pref, List<int[,]> sums)
        {
            Console.ForegroundColor = pref;
            Console.WriteLine("\nAll Array");
            for (int k = 0; k < sums.Count; k++)
            {
                int[,] a = sums[k];
                Console.WriteLine("Iteration Number: {0}",k);
                for (int i = 1; i < a.GetLength(0); i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (i >= 10)
                        Console.Write(i + "");
                    else
                        Console.Write(i + " ");
                    Console.ForegroundColor = pref;

                    for (int j = 1; j < a.GetLength(1); j++)
                    {
                        Console.Write(" " + a[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        private static int[,] AddTwoArray(List<int[,]> sums)
        {
            int[,] answer = new int[sums[0].GetLength(0), sums[0].GetLength(1)];
            for (int k = 0; k < sums.Count; k++)
            {
                int[,] a = sums[k];

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        answer[i, j] = answer[i, j] + a[i, j];
                    }                  
                }               
            }
            return answer;
        }



        private static int[,] MultiplicationOnKmo(int[,] array, int mult)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i,j] = array[i, j] * mult;
                }
            }
            return array;
        }

        private static int countOf_T5(int[,] array, int start, int exitGraph, out double R)
        {
            int count = 0;
            int exitGraphCount = 0;
            for (int i = 1; i < array.GetLength(0); i++)
            {
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 1) count++;

                }
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i, exitGraph] == 1) exitGraphCount++;
            }
            R = count;
            return count - exitGraphCount - start;

        }

        private static int countOfT4InEveryIteration_T4(int [,] array)
        {
            int countOfT4 = 0;
            int sum = 0;

            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    sum += array[i, j];
                }
                if (sum == 0) countOfT4++;
                sum = 0;
            }
            return countOfT4;
        }
        private static int countOfInsideGrapg_T2(int[,] array, int countStart, out int count, out int exitHraph)
        {
            count = 0;
            exitHraph = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                exitHraph = 0;
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    if (array[i, 0] == 1 && array[i, j] == 0)
                {
                            
                        exitHraph++;
                        if (exitHraph == array.GetLength(1) - 1) {
                            exitHraph = i;
                        }
                        
                    }
                }
            }



            for (int i = 0; i < array.GetLength(0); i++)
            {

                if (array[i, 0] == 1)
                {
                    for (int j = 1; j < array.GetLength(1); j++)
                    {
                        if (array[i, j] == 1)
                        {                     
                            count++;
                        }
                    }
                }
            }

            return array.GetLength(0) - countStart - count;
        }

        private static int countOfStartGraph_T1(int[,] array)
        {
            int countOfStart = 0;
            int sum = 0;
            for (int j = 0; j < array.GetLength(1); j++)
            {

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    sum += array[i, j];
                }
                if (sum == 0)
                {
                    countOfStart++;
                }
                sum = 0;
            }
            return countOfStart;
        }


        private static int countOfExitGraph_T3(int[,] array)
        {
            int countOfExit = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                countOfExit += array[i, 0];
            }
            return countOfExit;
        }

        private static int sumArray(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];
                }
            }
            return sum;
        }

        private static void printArray(int[,] array)
        {
            ConsoleColor pref = Console.ForegroundColor;
            Console.WriteLine();

            for (int i = 1; i < array.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (i >= 10)
                    Console.Write(i + "");
                else
                    Console.Write(i + " ");
                Console.ForegroundColor = pref;

                for (int j = 1; j < array.GetLength(1); j++)
                {
                    Console.Write(" " + array[i, j]);
                }
                Console.WriteLine();
            }
        }


        private static int[,] Multiplication(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }

    }
}
