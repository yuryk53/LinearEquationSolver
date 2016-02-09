using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using SysLinearEqSolver;
using System.Linq;
using System.Collections.Generic;

namespace SysLinearEqSolverTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double[,] A = {  {10, -1, 2,  0},
                             {-1, 11,-1,  3},
                             { 2, -1, 10,-1},
                             { 0,  3, -1, 8}
                          };
            double[] B = { 6, 25, -11, 15 };

            double[] initialGuess = { 0, 0, 0, 0 };

            EquationsSystem system = new SqLinearEquationsSystem(A, B);
            JacobiMethodSolver solver = new JacobiMethodSolver(initialGuess);

            system.Solver = solver;
            system.Solve();

            Assert.IsTrue(system.GetResultsArray().SequenceEqual(new double[] {1, 2, -1, 1}, new RoundComparer()));
        }

        [TestMethod]
        public void TestMethod2()
        {
            double[,] A = {  {2,1},
                             {5,7} 
                          };
            double[] B = { 11, 13 };

            double[] initialGuess = { 1, 1 };

            EquationsSystem system = new SqLinearEquationsSystem(A, B);
            JacobiMethodSolver solver = new JacobiMethodSolver(initialGuess);

            system.Solver = solver;
            system.Solve();

            Assert.IsTrue(system.GetResultsArray().SequenceEqual(
                new double[] { 7.111, -3.222},
                new RoundComparer()));
        }

        [TestMethod]
        public void TestMethod3()
        {
            double[,] A = {  {10,1,2},
                             { 0,5,2},
                             { 4,8,15}
                          };
            double[] B = { 3, 1, -1 };

            double[] initialGuess = { 0, 0, 0 };

            EquationsSystem system = new SqLinearEquationsSystem(A, B);
            JacobiMethodSolver solver = new JacobiMethodSolver(initialGuess);

            system.Solver = solver;
            system.Solve();

            Assert.IsTrue(system.GetResultsArray().SequenceEqual(
                new double[] { 0.33, 0.33, -0.33 },
                new RoundComparer()));
        }
    }

    public class RoundComparer : IEqualityComparer<double>
    {

        public bool Equals(double a, double b)
        {
            return Math.Round(a).Equals(Math.Round(b));
        }

        public int GetHashCode(double obj)
        {
            return obj.GetHashCode();
        }
    }

}
