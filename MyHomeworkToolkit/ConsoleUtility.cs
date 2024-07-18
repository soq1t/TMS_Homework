using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeworkToolkit
{
    public static class ConsoleUtility
    {
        public static void WriteColored(string message, ConsoleColor color)
        {
            ConsoleColor current = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.Write(message);
            Console.ForegroundColor = current;
        }

        public static void WriteLineColored(string message, ConsoleColor color)
        {
            WriteColored(message, color);
            Console.WriteLine();
        }

        public static void PressToContinue(ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.WriteLine();
            WriteColored("Нажмите любую клавишу для продолжения...", ConsoleColor.Yellow);
            Console.ReadKey(true);
        }

        public static void PrintError(
            string message,
            ConsoleColor errorColor = ConsoleColor.Red,
            bool clearBefore = false,
            bool clearAfter = false
        )
        {
            if (clearBefore)
                Console.Clear();

            if (string.IsNullOrEmpty(message))
                WriteLineColored("Ошибка!", errorColor);
            else
                WriteLineColored(message, errorColor);

            PressToContinue(errorColor);

            if (clearAfter)
                Console.Clear();
        }

        public static void ClearLine(int lineIndex)
        {
            (int Left, int Top) currentPosition = Console.GetCursorPosition();

            Console.SetCursorPosition(0, lineIndex);

            for (int i = 0; i < Console.BufferWidth; i++)
                Console.Write(' ');

            Console.SetCursorPosition(currentPosition.Left, currentPosition.Top);
        }

        public static void ClearLine() => ClearLine(Console.CursorTop);
    }
}
