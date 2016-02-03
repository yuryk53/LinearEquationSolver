using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLinearEqSolver
{
    /// <summary>
    /// Solver of equations system, Ax=B
    /// (equations depend on 'x')
    /// </summary>
    public abstract class EquationsSystem
    {
        private EquationsSystemSolver _solver;
        public EquationsSystemSolver Solver
        {
            get
            {
                return _solver;
            }
            set
            {
                _solver = value;
            }
        }
        /// <summary>
        /// coefficients of the linear equations system
        /// </summary>
        protected double[][] _coefficients;
        /// <summary>
        /// right sight coefficients (B matrix) of system Ax=B
        /// </summary>
        protected double[] _rightSight;
    
        public void Solve()
        {
            if (_solver != null)
            {
                _solver.Solve(_coefficients, _rightSight);
            }
            else throw new NullReferenceException("EquationsSystemSolver 'Solver' instance is not set!");
        }

        public override string ToString()
        {
            return PrintMe();
        }

        public abstract string PrintMe();

        /// <summary>
        /// Prints results (x1,x2,x3,...,xn)
        /// </summary>
        /// <returns>String, containing the results</returns>
        public virtual string PrintResults()
        {
            StringBuilder resultString = new StringBuilder();

            for (int i = 0; i < _solver.Results.Length; i++)
            {
                resultString.AppendFormat("x{0} = {1}\n", i + 1, _solver.Results[i]);
            }
            return resultString.ToString();
        }
    }
}
