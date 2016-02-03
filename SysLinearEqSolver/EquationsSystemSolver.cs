using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLinearEqSolver
{
    public abstract class EquationsSystemSolver
    {
        /// <summary>
        /// Contains the vector of results (vector X)
        /// </summary>
        public double[] Results { get; set; }

        /// <summary>
        /// Solves the system of equations of type
        /// A*x=B, where A-matrix of coefficients,
        ///              x-vector of unknows variables,
        ///              B-vector of conditions
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        public abstract void Solve(double[][] A, double[] B);
    }
}
