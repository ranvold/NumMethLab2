using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethLab2
{
    internal static class MatrixOperation
    {
        static public double[,] Multiply(double[,] matrix1, double[,] matrix2)
        {
            double[,] result = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        result[i,j] += matrix1[i,k] * matrix2[k,j];
                    }
                }
            }
            return result;
        }
        static public double[] Multiply(double[,] matrix, double[] column)
        {
            double[] result = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[i] += matrix[i,j] * column[j];
                }
            }
            return result;
        }
        static public double[] Multiply(double[] matrix, double coef)
        {
            double[] result = new double[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                result[i] += matrix[i] * coef;
            }
            return result;
        }
        static public void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0:F3}", matrix[i,j]));
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
        }
        static public void PrintMatrix(double[] matrix)
        {
            foreach (double column in matrix)
            {
                Console.Write(String.Format("{0:F3}", column));
                Console.Write("\t");
            }
        }
        static public double[] Subtract(double[] matrix1, double[] matrix2)
        {
            double[] result = new double[matrix1.Length];
            for (int i = 0; i < matrix1.Length; i++)
            {
                result[i] += matrix1[i] - matrix2[i];
            }
            return result;
        }

        static public double[,] Transpose(double[,] matrix)
        {
            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[i,j] = matrix[j,i];
                }
            }
            return result;
        }

        static public double GetDeterminant(double[,] matrix)
        {
            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[i,j] = matrix[i,j];
                }
            }
            double determ = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = matrix.GetLength(0) - 1; j > i; j--)
                {
                    double coef = result[j,i];
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        result[j,k] = result[j,k] - result[i,k] * coef / result[i,i];
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                determ *= result[i,i];
            }
            return determ;
        }


        static public double[,] GetInverse(double[,] matrix)
        {
            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[i,j] = matrix[i,j];
                }
            }
            double[,] e = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        e[i,j] = 1;
                    }
                    else
                    {
                        e[i,j] = 0;
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = matrix.GetLength(0) - 1; j > i; j--)
                {
                    double coef = result[j,i];
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        result[j,k] = result[j,k] - result[i,k] * coef / result[i,i];
                        e[j,k] = e[j,k] - e[i,k] * coef / result[i,i];
                    }
                }
            }
            for (int i = matrix.GetLength(0) - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    double coef = result[j,i];
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        result[j,k] = result[j,k] - result[i,k] * coef / result[i,i];
                        e[j,k] = e[j,k] - e[i,k] * coef / result[i,i];
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    e[i,j] /= result[i,i];
                }
            }
            return e;
        }
    }
}
