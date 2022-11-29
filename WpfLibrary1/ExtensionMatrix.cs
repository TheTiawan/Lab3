using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary1
{
    public static class ExtensionMatrix
    {

        public static void FillMatrix(this Matrix<int> numbers, int rows, int column, int min, int max)
        {
            Random rnd = new Random();
            for (int i = 0; i < numbers.Rows; i++)
            {
                for (int j = 0; j < numbers.Columns; j++)
                {
                    numbers[i, j] = rnd.Next(min, max);
                }
            }
        }

        public static int Count(this Matrix<int> matr)
        {
            int sum = 0;
            for (int j = 1; j < matr.Rows; j += 2)
            {
                for (int i = 0; i < matr.Columns; i++)
                {
                    sum -= matr[i, j];
                }
            }
            return sum;
        }

    }
}
