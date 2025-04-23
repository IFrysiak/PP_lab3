using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_lab3
{
    public class MatrixMultiplier
    {
        public static Matrix MultiplySequential(Matrix a, Matrix b)
        {
            Matrix result = new Matrix(a.Rows, b.Cols);

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Cols; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < a.Cols; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        public static Matrix MultiplyParallel(Matrix a, Matrix b, int maxThreads)
        {
            Matrix result = new Matrix(a.Rows, b.Cols);
            var options = new ParallelOptions { MaxDegreeOfParallelism = maxThreads };

            Parallel.For(0, a.Rows, options, i =>
            {
                for (int j = 0; j < b.Cols; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < a.Cols; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            });
            return result;
        }
    }
}
