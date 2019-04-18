using System;
using System.Numerics;

namespace ContinuationPassingStyle
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new QuadraticEquationSolver();
            WorkflowResult flag = solver.Start(1, 10, 16, out Tuple<Complex, Complex> result);
            if (flag == WorkflowResult.Success)
            {
                // USE result
            }
        }
    }
}
