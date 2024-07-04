using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Homework4
{
    public enum AmountMode
    {
        Positive,
        Negative
    }

    public enum SortMode
    {
        Ascending,
        Descending
    }

    public class Matrix
    {
        private readonly int[][] _array;
        private readonly int _x;
        private readonly int _y;

        public Matrix(int[][] array)
        {
            _array = array;
            _x = _array.GetLength(0);
            _y = _array.GetLength(1);
        }

        private static Dictionary<AmountMode, string> _amountMap = new Dictionary<
            AmountMode,
            string
        >()
        {
            { AmountMode.Positive, "положительных" },
            { AmountMode.Negative, "отрицательных" },
        };

        private static Dictionary<SortMode, string> _sortMap = new Dictionary<SortMode, string>()
        {
            { SortMode.Ascending, "возрастанию" },
            { SortMode.Descending, "убыванию" },
        };

        public void PrintMatrix()
        {
            for (int i = 0; i < _x; i++)
            for (int j = 0; j < _y; j++)
            {
                Console.Write(_array[i][j]);
                if (j + 1 < _y)
                    Console.Write("\t\n");
                else
                    Console.Write("\n");
            }
        }

        private int GetAmount(AmountMode mode)
        {
            int amount = 0;

            for (int i = 0; i < _x; i++)
            for (int j = 0; j < _y; j++)
                if (mode == AmountMode.Positive && _array[i][j] > 0)
                    amount++;
                else if (mode == AmountMode.Negative && _array[i][j] < 0)
                    amount++;

            return amount;
        }

        public void PrintAmount(AmountMode mode) =>
            Console.WriteLine($"Кол-во {_amountMap[mode]} чисел в матрице: {GetAmount(mode)}");

        private void Invert()
        {
            for (int i = 0; i < _x; i++)
            {
                int[] buffer = (int[])_array[i].Clone();

                for (int j = 0; j < _y; j++)
                    _array[i][j] = buffer[-_y - 1 - j];
            }
        }

        public void PrintInverted()
        {
            Invert();
            Console.WriteLine("Инвертированная матрица:\n");
            PrintMatrix();
        }

        private void Sort(SortMode mode)
        {
            for (int i = 0; i < _x; i++)
            {
                for (int a = 0; a < _y - 1; a++)
                {
                    for (int b = a + 1; b < _y; b++)
                    {
                        if (mode == SortMode.Ascending && _array[i][a] > _array[i][b])
                        {
                            int buffer = _array[i][a];
                            _array[i][a] = _array[i][b];
                            _array[i][b] = buffer;
                        }
                        else if (mode == SortMode.Descending && _array[i][a] < _array[i][b])
                        {
                            int buffer = _array[i][a];
                            _array[i][a] = _array[i][b];
                            _array[i][b] = buffer;
                        }
                    }
                }
            }
        }

        public void PrintSorted(SortMode mode)
        {
            Sort(mode);
            Console.WriteLine($"Отсортированная по {_sortMap[mode]} матрица:\n");
            PrintMatrix();
        }
    }
}
