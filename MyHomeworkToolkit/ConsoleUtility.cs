using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeworkToolkit
{
    public static class ConsoleUtility
    {
        public static void WriteColored(
            string message,
            ConsoleColor foreground = ConsoleColor.Yellow,
            ConsoleColor background = ConsoleColor.Black
        )
        {
            Encoding currentEncoding = Console.OutputEncoding;
            Console.OutputEncoding = Encoding.UTF8;

            ConsoleColor currentForeground = Console.ForegroundColor;
            ConsoleColor currentBackground = Console.BackgroundColor;

            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;

            Console.Write(message);

            Console.ForegroundColor = currentForeground;
            Console.BackgroundColor = currentBackground;
            Console.OutputEncoding = currentEncoding;
        }

        public static void WriteLineColored(
            string message,
            ConsoleColor foreground = ConsoleColor.Yellow,
            ConsoleColor background = ConsoleColor.Black
        )
        {
            WriteColored(message, foreground, background);
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

            StringBuilder emptyString = new StringBuilder();
            for (int i = 0; i < Console.BufferWidth; i++)
                emptyString.Append(' ');

            Console.Write(emptyString.ToString());

            Console.SetCursorPosition(currentPosition.Left, currentPosition.Top);
        }

        public static void ClearLine() => ClearLine(Console.CursorTop);
    }
}
