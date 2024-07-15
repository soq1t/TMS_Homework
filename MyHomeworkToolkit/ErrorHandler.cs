using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeworkToolkit
{
    public static class ErrorHandler
    {
        public static void ShowError(
            string message = null,
            bool clearBefore = false,
            bool clearAfter = false
        )
        {
            ConsoleColor currentColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;

            if (clearBefore)
                Console.Clear();

            if (string.IsNullOrEmpty(message))
                Console.WriteLine("Ошибка!");
            else
                Console.WriteLine(message);

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);

            if (clearAfter)
                Console.Clear();

            Console.ForegroundColor = currentColor;
        }
    }
}
