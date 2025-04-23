using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_lab3
{
    public class Matrix
    {
        private readonly double[,] _data;
        public int Rows { get; }
        public int Cols { get; }

        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            _data = new double[rows, cols];
        }

        public double this[int row, int col]
        {
            get => _data[row, col];
            set => _data[row, col] = value;
        }

        public void FillRandom(Random random, int min = 0, int max = 100)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    _data[i, j] = random.Next(min, max);
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(_data[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
