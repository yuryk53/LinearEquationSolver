using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysLinearEqSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] A = { {2,1},
                             {5,7} };
            double[] B = { 11, 13 };

            double[] initialGuess = { 1, 1 };

            EquationsSystem system = new SqLinearEquationsSystem(A, B);
            JacobiMethodSolver solver = new JacobiMethodSolver(initialGuess);

            system.Solver = solver;
            system.Solve();

            Console.WriteLine(system.PrintResults());
        }
    }
}
