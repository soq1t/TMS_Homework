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

        private static string GetData(string preMessage) =>
            GetData(preMessage, NotEmptyStringChecker);

        #region Text Input
        public static string? GetTextData(string preMessage, Func<string, bool> checker) =>
            GetData(preMessage, checker) as string;

        public static string GetTextData(string preMessage) =>
            (string)GetData(preMessage, NotEmptyStringChecker);
        #endregion

        #region Digit Input
        public static int GetIntData(string preMessage, Func<string, bool> checker)
        {
            int @int;
            bool isIntInput = false;
            do
            {
                isIntInput = Int32.TryParse(GetData(preMessage, checker), out @int);

                if (!isIntInput)
                    ConsoleUtility.WriteLineColored(
                        new Colored("Входные данные должны быть числом типа ", ConsoleColor.Red),
                        new Colored("[int]", ConsoleColor.Yellow),
                        new Colored(" !", ConsoleColor.Red)
                    );
            } while (!isIntInput);

            return @int;
        }

        public static int GetIntData(string preMessage) =>
            GetIntData(preMessage, NotEmptyStringChecker);

        public static double GetDoubleData(string preMessage, Func<string, bool> checker)
        {
            double @double;
            bool isDoubleInput = false;
            do
            {
                isDoubleInput = Double.TryParse(GetData(preMessage, checker), out @double);

                if (!isDoubleInput)
                    ConsoleUtility.WriteLineColored(
                        new Colored("Входные данные должны быть числом типа ", ConsoleColor.Red),
                        new Colored("[double]", ConsoleColor.Yellow),
                        new Colored(" !", ConsoleColor.Red)
                    );
            } while (!isDoubleInput);

            return @double;
        }

        public static double GetDoubleData(string preMessage) =>
            GetDoubleData(preMessage, NotEmptyStringChecker);

        public static decimal GetDecimalData(string preMessage, Func<string, bool> checker)
        {
            decimal @decimal;
            bool isDecimalInput = false;
            do
            {
                isDecimalInput = Decimal.TryParse(GetData(preMessage, checker), out @decimal);

                if (!isDecimalInput)
                    ConsoleUtility.WriteLineColored(
                        new Colored("Входные данные должны быть числом типа ", ConsoleColor.Red),
                        new Colored("[double]", ConsoleColor.Yellow),
                        new Colored(" !", ConsoleColor.Red)
                    );
            } while (!isDecimalInput);

            return @decimal;
        }

        public static decimal GetDecimalData(string preMessage) =>
            GetDecimalData(preMessage, NotEmptyStringChecker);
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

        #endregion
    }
}
