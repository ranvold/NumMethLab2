using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethLab2
{
    internal static class SquareRootMethod
    {
        private static double[,] _matrix =
        {
            {1, 2, 0},
            {2, 2, 4},
            {0, 4, 3}
        };

        private static double[] _result = { 11, 34, 31 };

        private static double[,] _diagonal =
        {
            {0, 0, 0},
            {0, 0, 0},
            {0, 0, 0}
        };

        private static double[,] _rightTriangle =
        {
            {0, 0, 0},
            {0, 0, 0},
            {0, 0, 0}
        };

        private static double[,] _finalMatrix =
        {
            {0, 0, 0},
            {0, 0, 0},
            {0, 0, 0}
        };

        private static double[] x = { 0, 0, 0 };

        private static double[] y = { 0, 0, 0 };

        public static void RunSquareRootMethod(double e)
        {
            Console.WriteLine("Initial matrix:");
            MatrixOperation.PrintMatrix(_matrix);
            Console.WriteLine("\n");
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < i; j++)
                {
                    sum += Math.Pow(Math.Abs(_rightTriangle[j,i]), 2) * _diagonal[j,j];
                }
                _diagonal[i,i] = Math.Sign(_matrix[i,i] - sum);
                _rightTriangle[i,i] = Math.Sqrt(Math.Abs(_matrix[i,i] - sum));
                for (int j = i + 1; j < _matrix.GetLength(1); j++)
                {
                    sum = 0;
                    for (int k = 0; k < i; k++)
                    {
                        sum += _rightTriangle[k,i] * _diagonal[k,k] * _rightTriangle[k,j];
                    }
                    _rightTriangle[i,j] = (_matrix[i,j] - sum) / (_diagonal[i,i] * _rightTriangle[i,i]);
                }
            }
            _finalMatrix = MatrixOperation.Multiply(MatrixOperation.Transpose(_rightTriangle), _diagonal);
            for (int i = 0; i < y.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < i; j++)
                {
                    sum += _finalMatrix[i,j] * y[j];
                }
                y[i] = (_result[i] - sum) / _finalMatrix[i,i];
            }
            for (int i = x.Length - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < x.Length; j++)
                {
                    sum += _rightTriangle[i,j] * x[j];
                }
                x[i] = (y[i] - sum) / _rightTriangle[i,i];
            }
            for (int i = 0; i < x.Length; i++)
            {
                Console.Write("x" + i + '\t');
            }
            Console.WriteLine('\n');
            MatrixOperation.PrintMatrix(x);
            Console.WriteLine('\n');
            Console.Write("Determinant: ");
            Console.Write("{0:F3}", MatrixOperation.GetDeterminant(_matrix));
            Console.WriteLine('\n');
            Console.WriteLine("Inverse matrix:");
            MatrixOperation.PrintMatrix(MatrixOperation.GetInverse(_matrix));
        }
    }
}
