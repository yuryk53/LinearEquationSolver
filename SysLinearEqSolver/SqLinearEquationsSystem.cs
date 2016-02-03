using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLinearEqSolver
{
    public class SqLinearEquationsSystem : LinearEquationsSystem
    {
        /// <summary>
        /// creates new sqare linear equations system
        /// </summary>
        /// <param name="X">coefficients matrix of the linear equations</param>
        /// <param name="B">right-sight vector of eqations</param>
        public SqLinearEquationsSystem(double[,] A, double[] B)
            : base(A, B)
        { }
    }
}
