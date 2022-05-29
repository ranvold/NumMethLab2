using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethLab2
{
    internal static class JacobiMethod
    {
        private static double[,] _matrix =
        {
            { 5, 1, 1, 0 },
            { 1, 2, 0, 0 },
            { 1, 0, 4, 2 },
            { 0, 0, 2, 3 }
        };

        private static double[] _b = { 17, 8, 28, 23 };

        private static List<double> qList = new List<double>();

        private static List<double> coefList = new List<double>();

        private static void AddCoef(double a)
        {
            coefList.Add(1 / a);
        }

        public static bool Check()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {                     
                double sum = 0;  
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    sum += j == i ? 0 : _matrix[i,j];
                }

                if (_matrix[i,i] < sum)
                {
                    return false;
                }
                qList.Add(sum / _matrix[i,i]);                            
                AddCoef(_matrix[i,i]);                                     
            }
            return true;
        }

        private static double qMax()
        {
            return qList.Max();
        }

        private static int IterCount(double e)
        {
            double q = qMax();
            for (int k = 0; true; k++)
            {
                if (Math.Pow(q, k) / (1 - q) < e)
                    return k;
            }
        }
        private static void PrintResult(double[] res)
        {
            Console.WriteLine("Result:");
            for (int i = 0; i < res.Length; i++)
            {
                Console.Write("x" + i + " ");
                Console.WriteLine(String.Format("{0:F1}",  res[i]));
            }
        }
        public static void RunJacobiMethod(double e)
        {
            int k = IterCount(e);       
           Console.WriteLine("IterCount: " + k);

            double[] tmp = { 0, 0, 0, 0 };      
            double[] res = new double[4];
            for (int i = 0; i < k; i++)
            {                  
                res[0] = coefList[0] * (-tmp[2] - tmp[3] + _b[0]);
                res[1] = coefList[1] * (-tmp[3] + _b[1]);
                res[2] = coefList[2] * (-tmp[0] + _b[2]);
                res[3] = coefList[3] * (-tmp[0] - tmp[1] + _b[3]);

                Array.Copy(res, 0, tmp, 0, 4);
            }
            PrintResult(res);
        }
    }
}
