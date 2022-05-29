using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethLab2
{
    internal static class SimpleIterMethod
    {
        private static double[,] matrix =
        {
            { 4, 3, 1, 0 },
            { -2, 2, 6, 1 },
            { 0, 5, 2, 3 },
            { 0, 1, 2, 7 }
        };

        private static double[] result = { 14, 31, 33, 45 };

        private static double[] x0 = { 0, 0, 0, 0 };

        private static double[] x1 = { 0, 0, 0, 0 };

        private static double t0 = 0.141184;


        public static void RunSimpleIterMethod(double e)
        {
            Console.WriteLine("Initial matrix:");
            MatrixOperation.PrintMatrix(matrix);
            Console.WriteLine();
            for (int i = 0; i < 7; i++)
            {
                x1 = MatrixOperation.Subtract(x0, MatrixOperation.Multiply(MatrixOperation.Subtract(MatrixOperation.Multiply(matrix, x0), result), t0));
                if ((Math.Abs(x1[0] - x0[0]) < e) && (Math.Abs(x1[1] - x0[1]) < e) && (Math.Abs(x1[2] - x0[2]) < e) && (Math.Abs(x1[3] - x0[3]) < e))
                {
                    break;
                }
                for (int j = 0; j < x0.Length; j++)
                {
                    x0[j] = x1[j];
                }
            }
            for (int i = 0; i < x1.Length; i++)
            {
                Console.Write("x" + i + '\t');
            }
            Console.WriteLine();
            MatrixOperation.PrintMatrix(x1);
        }
    }
}
