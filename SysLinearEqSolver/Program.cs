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
            //double[,] A = { {2,1},
            //                 {5,7} };
            Console.Write("Enter number of equetions: ");
            int n = int.Parse(Console.ReadLine());
            int m = n;
            // Console.Write("Введите m: ");
            // int m = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            Console.WriteLine("Filling matrix:");
            double[,] A = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("[{0},{1}]=", i, j);

                    A[i, j] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n");
                }
            }
            Console.WriteLine("\n");
            Console.Write("Enter B: ");
            //double[] B = { 11, 13 };

            double[] B = new double[n];

            for (int j = 0; j < m; j++)
            {
                Console.WriteLine("[{0}]=", j);

                B[j] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");
            }


            // double[] initialGuess = { 1, 1 };
            Console.WriteLine("\n");
            Console.Write("Enter initial guess: ");
            double[] initialGuess = new double[n];

            for (int j = 0; j < m; j++)
            {
                Console.WriteLine("[{0}]=", j);

                initialGuess[j] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");
            }

            //EquationsSystem system = new SqLinearEquationsSystem(A, B);
            //JacobiMethodSolver solver = new JacobiMethodSolver(initialGuess);

            //system.Solver = solver;
            //system.Solve();

            //Console.WriteLine(system.PrintResults());


            Console.WriteLine("Jacobi method:\n");

            EquationsSystem system = new SqLinearEquationsSystem(A, B);
            JacobiMethodSolver solver = new JacobiMethodSolver();

            system.Solver = solver;
            system.Solve();

            Console.WriteLine(system.PrintResults());

            Console.WriteLine("Gauss-Jordan method:\n");
            EquationsSystem system1 = new SqLinearEquationsSystem(A, B);
            GaussJordanSolver solver1 = new GaussJordanSolver();

            system1.Solver = solver1;
            system1.Solve();

            Console.WriteLine(system1.PrintResults());
        }
    }
}
