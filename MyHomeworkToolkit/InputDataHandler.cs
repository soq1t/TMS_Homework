using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeworkToolkit
{
    public static class InputDataHandler
    {
        private static object GetData(string preMessage, Func<object, bool> checker)
        {
            bool isDataCorrect = true;
            string input;

            do
            {
                ConsoleUtility.WriteLineColored(preMessage, ConsoleColor.Yellow);
                input = Console.ReadLine();

                isDataCorrect = checker.Invoke(input);
                Console.WriteLine();
            } while (!isDataCorrect);

            return input;
        }

        private static object GetDigitData(string preMessage, Func<object, bool> checker)
        {
            bool isDataCorrect = true;
            string input;

            do
            {
                ConsoleUtility.WriteLineColored(preMessage, ConsoleColor.Yellow);
                input = Console.ReadLine();

                if (!IsDigit(input))
                {
                    PrintError("Вводмиое значение должно быть числом!");
                    continue;
                }

                isDataCorrect = checker.Invoke(input);
                Console.WriteLine();
            } while (!isDataCorrect);

            return input;

            bool IsDigit(string value)
            {
                if (Int32.TryParse(value, out int @int))
                    return true;

                if (double.TryParse(value, out double @double))
                    return true;

                if (decimal.TryParse(value, out decimal @decimal))
                    return true;
                return false;
            }
        }

        #region Text Input
        public static string? GetTextData(string preMessage, Func<object, bool> checker) =>
            GetData(preMessage, checker) as string;

        public static string GetTextData(string preMessage) =>
            (string)GetData(preMessage, NotEmptyStringChecker);
        #endregion

        #region Digit Input

        public static int GetIntData(string preMessage, Func<object, bool> checker) =>
            (int)GetDigitData(preMessage, checker);

        public static double GetDoubleData(string preMessage, Func<object, bool> checker) =>
            (double)GetDigitData(preMessage, checker);

        public static decimal GetDecimalData(string preMessage, Func<object, bool> checker) =>
            (decimal)GetDigitData(preMessage, checker);

        #endregion

        #region Default Checkers
        private static bool PrintError(string message)
        {
            ConsoleUtility.WriteLineColored(message, ConsoleColor.Red);
            Console.WriteLine();
            return false;
        }

        private static bool NotEmptyStringChecker(object value)
        {
            if (string.IsNullOrEmpty((string)value))
                return PrintError("Вводимая строка не должна быть пустой!");

            return true;
        }

        private static bool MoreThanZeroChecker(object value)
        {
            if (value is int)
            {
                if ((int)value < 0)
                    return PrintError("Значение не может быть отрицательным!");
            }
            else if (value is double)
            {
                if ((double)value < 0)
                    return PrintError("Значение не может быть отрицательным!");
            }
            else if (value is decimal)
            {
                if ((decimal)value < 0)
                    return PrintError("Значение не может быть отрицательным!");
            }

            return true;
        }
        #endregion
    }
}
