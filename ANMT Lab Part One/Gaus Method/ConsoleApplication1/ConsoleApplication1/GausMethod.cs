using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class GausMethod
    {
        public uint RowCount;
        public uint ColumCount;
        public double[][] Matrix { get; set; }
        public double[] RightPart { get; set; }
        public double[] Answer { get; set; }


        public GausMethod(uint Row, uint Colum)
        {
            RightPart = new double[Row];
            Answer = new double[Row];
            Matrix = new double[Row][];
            for (int i = 0; i < Row; i++)
                Matrix[i] = new double[Colum];
            RowCount = Row;
            ColumCount = Colum;

          
            for (int i = 0; i < Row; i++)
            {
                Answer[i] = 0;
                RightPart[i] = 0;
                for (int j = 0; j < Colum; j++)
                    Matrix[i][j] = 0;
            }
        }

 
        public int SolveMatrix()
        {
            if (RowCount != ColumCount)
                return 1; // have not answer

            for (int i = 0; i < RowCount - 1; i++)
            {
                ///SortRows(i);
                for (int j = i + 1; j < RowCount; j++)
                {
                    if (Matrix[i][i] != 0) // if main element != 0 
                    {
                        double MultElement = Matrix[j][i] / Matrix[i][i];
                        for (int k = i; k < ColumCount; k++)
                            Matrix[j][k] -= Matrix[i][k] * MultElement;
                        RightPart[j] -= RightPart[i] * MultElement;
                    }
                                  
                }
            }

            //Find Answers X's
            for (int i = (int)(RowCount - 1); i >= 0; i--)
            {
                Answer[i] = RightPart[i];

                for (int j = (int)(RowCount - 1); j > i; j--)
                    Answer[i] -= Matrix[i][j] * Answer[j];

                if (Matrix[i][i] == 0)
                    if (RightPart[i] == 0)
                        return 2; // have a many answers
                    else
                        return 1; // have not a answers

                Answer[i] /= Matrix[i][i];

            }
            return 0;
        }


        public override String ToString()
        {
            String S = "";
            for (int i = 0; i < RowCount; i++)
            {
                S += "\r\n";
                for (int j = 0; j < ColumCount; j++)
                {
                    S += Matrix[i][j].ToString("F04") + "\t";
                }

                S += "\t" + RightPart[i].ToString("F04");
                S += "\t\t" + Answer[i].ToString("F08");
               
            }
            return S;
        }

    }
}
