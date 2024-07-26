using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeworkToolkit
{
    public static class InputDataHandler
    {
        private static object GetData(string preMessage, Func<string, bool> checker)
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
            (int)GetData(preMessage, checker);

        public static double GetDoubleData(string preMessage, Func<string, bool> checker) =>
            (double)GetData(preMessage, checker);

        public static decimal GetDecimalData(string preMessage, Func<string, bool> checker) =>
            (decimal)GetData(preMessage, checker);

        #endregion

        #region Default Checkers
        public static bool PrintError(string message)
        {
            ConsoleUtility.WriteLineColored(message, ConsoleColor.Red);
            Console.WriteLine();
            return false;
        }

        public static bool NotEmptyStringChecker(string value)
        {
            if (string.IsNullOrEmpty(value))
                return PrintError("Вводимая строка не должна быть пустой!");

            return true;
        }

        public static bool MoreThanZeroChecker(string value)
        {
            if (Int32.TryParse(value.Trim(), out int @int))
            {
                if (@int < 0)
                    return PrintError("Значение не может быть отрицательным!");
                else
                    return true;
            }
            else if (double.TryParse(value.Trim(), out double @double))
            {
                if (@double < 0)
                    return PrintError("Значение не может быть отрицательным!");
                else
                    return true;
            }
            else if (decimal.TryParse(value.Trim(), out decimal @decimal))
            {
                if (@decimal < 0)
                    return PrintError("Значение не может быть отрицательным!");
                else
                    return true;
            }
            else
                return PrintError("Входящее значение должно быть числом!");
        }
        #endregion
    }
}
