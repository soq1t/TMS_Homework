using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeworkToolkit
{
    public static class InputDataHandler
    {
        private static string GetData(string preMessage, Func<string, bool> checker)
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

        #region Text Input
        public static string? GetTextData(string preMessage, Func<string, bool> checker) =>
            GetData(preMessage, checker) as string;

        public static string GetTextData(string preMessage) =>
            (string)GetData(preMessage, NotEmptyStringChecker);
        #endregion

        #region Digit Input

        public static int GetIntData(string preMessage, Func<string, bool> checker) =>
            Int32.Parse(GetData(preMessage, checker));

        public static double GetDoubleData(string preMessage, Func<string, bool> checker) =>
            Double.Parse(GetData(preMessage, checker));

        public static decimal GetDecimalData(string preMessage, Func<string, bool> checker) =>
            Decimal.Parse(GetData(preMessage, checker));

        #endregion

        #region Default Checkers


        public static void PrintError(string message)
        {
            ConsoleUtility.WriteLineColored(message, ConsoleColor.Red);
            Console.WriteLine();
        }

        public static bool NotEmptyStringChecker(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                PrintError("Вводимая строка не должна быть пустой!");
                return false;
            }

            return true;
        }

        public static bool MoreThanZeroChecker(string value)
        {
            if (Int32.TryParse(value.Trim(), out int @int))
            {
                if (@int < 0)
                {
                    PrintError("Значение не может быть отрицательным!");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (double.TryParse(value.Trim(), out double @double))
            {
                if (@double < 0)
                {
                    PrintError("Значение не может быть отрицательным!");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (decimal.TryParse(value.Trim(), out decimal @decimal))
            {
                if (@decimal < 0)
                {
                    PrintError("Значение не может быть отрицательным!");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                PrintError("Входящее значение должно быть числом!");
                return false;
            }
        }

        public static bool DigitChecker(string value, Type type)
        {
            bool result = false;

            if (type is int)
            {
                result = Int32.TryParse(value.Trim(), out int @int);
            }
            if (type is double)
            {
                result = double.TryParse(value.Trim(), out double @double);
            }
            if (type is decimal)
            {
                result = decimal.TryParse(value.Trim(), out decimal @decimal);
            }

            if (result)
            {
                return true;
            }
            else
            {
                PrintError($"Заданное значение не является числом с типом {type}!");
                return false;
            }
        }
        #endregion
    }
}
