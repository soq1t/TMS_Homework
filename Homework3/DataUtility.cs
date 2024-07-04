using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public static class DataUtility
    {
        public static double GetDouble(string paramName)
        {
            bool isInputCorrect = true;
            double result;

            do
            {
                if (!isInputCorrect)
                {
                    Console.WriteLine("Неверный формат числа!");
                    Console.WriteLine();
                }

                Console.Write($"Введите число {paramName}: ");
                string input = Console.ReadLine();

                isInputCorrect = double.TryParse(input, out result);
            } while (!isInputCorrect);

            return result;
        }
    }
}
