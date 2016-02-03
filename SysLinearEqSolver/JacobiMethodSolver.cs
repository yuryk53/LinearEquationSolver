using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLinearEqSolver
{
    public class JacobiMethodSolver : EquationsSystemSolver
    {
        double[] _initialGuess = null;
        const double stdEps = 1e-5;
        double _eps = stdEps;

        public JacobiMethodSolver(double eps = stdEps)
        { this._eps = eps; }

        public JacobiMethodSolver(double[] initialGuess, double eps = stdEps)
        {
            this._initialGuess = initialGuess;
            this._eps = eps;
        }

        //https://en.wikipedia.org/wiki/Jacobi_method
        public override void Solve(double[][] A, double[] B)
        {
            if (_initialGuess != null)
            {
                if (_initialGuess.Length != A.GetLength(0))
                    throw new ArgumentOutOfRangeException("Incorrect dimension of initial guess supplied!");
            }
            else
            {
                _initialGuess = new double[A.GetLength(0)];
                Array.Clear(_initialGuess, 0, _initialGuess.Length); //populate with zeroes
            }

            double [] X = new double[A[0].Length];
            double[] X_next = new double[A[0].Length];
            Array.Copy(_initialGuess, X, _initialGuess.Length);
            int n = A[0].Length; //dimension
            while (!IsAccurate(A, X, B))
            {
                for (int i = 0; i < n; i++)
                {
                    double z = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (j != i)
                        {
                            z += A[i][j] * X[j];
                        }
                    }
                    X_next[i] = (B[i] - z) / A[i][i];
                }
                X = X_next;
                X_next = new double[n];
            }

            this.Results = X;
        }

        /// <summary>
        /// Returns true, if X values are accurate, false - if not
        /// (uses epsilon value for that)
        /// </summary>
        /// <param name="X">calculated vector X</param>
        /// <returns>true, if X values are accurate, false - if not</returns>
        private bool IsAccurate(double[][] A, double[] X, double[] B)
        {
            for (int i = 0; i < A.Length; i++)
            {
                double res = 0;
                for (int j = 0; j < A[i].Length; j++)
                {
                    res+=A[i][j] * X[j];
                }

                if (Math.Abs(res - B[i]) < _eps)
                    continue;
                else return false;
            }
            return true;
        }
    }
}
