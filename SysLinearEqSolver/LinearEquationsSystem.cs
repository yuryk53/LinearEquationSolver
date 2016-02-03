using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLinearEqSolver
{
    public class LinearEquationsSystem : EquationsSystem
    {
        /// <summary>
        /// Creates new linear equations system
        /// </summary>
        /// <param name="coefficients">input coefficients</param>
        public LinearEquationsSystem(double[][] coefficients, double[] rightSight)
        {
            if (_coefficients.Length != rightSight.Length)
                throw new ArgumentOutOfRangeException("Coefficients matrix size doesn't match the right-sight vector size!");

            this._coefficients = coefficients;
            this._rightSight = rightSight;
        }

        public LinearEquationsSystem(double[,] coefficients, double[] rightSight)
        {
            _coefficients = new double[coefficients.GetLength(0)][];
            for (int i = 0; i < coefficients.GetLength(0); i++)
            {
                _coefficients[i] = new double[coefficients.GetLength(0)];
                for (int j = 0; j < coefficients.GetLength(0); j++)
                {
                    _coefficients[i][j] = coefficients[i, j];
                }
            }

            if (_coefficients.Length != rightSight.Length)
                throw new ArgumentOutOfRangeException("Coefficients matrix size doesn't match the right-sight vector size!");

            this._rightSight = rightSight;
        }

        public override string PrintMe()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _coefficients.Length; i++)
            {
                for (int j = 0; j < _coefficients[i].Length; j++)
                {
                    string sign = _coefficients[i][j]<0 ? "-" : "+";
                    sb.AppendFormat("{0}{1}*x", sign, Math.Abs(_coefficients[i][j]));
                }
                sb.AppendFormat("={0}\n", _rightSight[i]);
            }
            return sb.ToString();
        }
    }
}
