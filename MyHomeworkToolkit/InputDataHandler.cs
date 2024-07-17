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

        #region Text Input
        public static string? GetTextData(string preMessage, Func<object, bool> checker) =>
            GetData(preMessage, checker) as string;

        public static string GetTextData(string preMessage) =>
            (string)GetData(preMessage, NotEmptyStringChecker);
        #endregion

        #region Default Checkers
        private static bool NotEmptyStringChecker(object value)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                ConsoleUtility.WriteLineColored(
                    "Вводимая строка не должна быть пустой!",
                    ConsoleColor.Red
                );
                Console.WriteLine();
                return false;
            }

            return true;
        }
        #endregion
    }
}
