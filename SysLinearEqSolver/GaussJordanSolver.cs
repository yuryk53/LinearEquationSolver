using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLinearEqSolver
{
    public class GaussJordanSolver : EquationsSystemSolver
    {
        public override void Solve(double[][] A, double[] B)
        {
            int N = A.GetLength(0);
            // throw new NotImplementedException();
            double[] x = new double[N];

            //Console.WriteLine("row A");
            //Console.WriteLine(string.Join("\n", A.Select(a => string.Concat(a.Select(v => string.Format("{0,12:F8}", v))))));
            //Console.WriteLine("vector B");
            //Console.WriteLine(string.Join("\n", B.Select(v => string.Format("{0,12:F8}", v))));
            //Console.WriteLine();

            //start
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    double s = A[j][i] / A[i][i];
                    for (int k = i; k < N; k++)
                    {
                        A[j][k] -= A[i][k] * s;
                    }
                    B[j] -= B[i] * s;
                }
            }

            //retreat 
            for (int i = N - 1; i >= 0; i--)
            {
                B[i] /= A[i][i];
                A[i][i] /= A[i][i];
                for (int j = i - 1; j >= 0; j--)
                {
                    double s = A[j][i] / A[i][i];
                    A[j][i] -= s;
                    B[j] -= B[i] * s;
                }
            }

            /*
            for (int i = 0; i < N; i++)
            {
                x[i] = B[i] / A[i][i];
            }
            */
            x = Enumerable.Range(0, N).Select(i => B[i] / A[i][i]).ToArray();
            this.Results = x;
        }
    }
}
