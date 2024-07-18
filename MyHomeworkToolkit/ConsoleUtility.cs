using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeworkToolkit
{
    public static class ConsoleUtility
    {
        #region Вывод текста на консоль
        /// <summary>
        /// Выводит в консоль заданную строку
        /// </summary>
        /// <param name="obj">Выводимый в консоль объект (obj?.ToString() ?? string.Empty)</param>
        /// <param name="foreground">Цвет выводимого текста</param>
        /// <param name="background">Цвет фона выводимого текста</param>
        public static void WriteColored(
            object? message,
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

            Console.Write(message?.ToString() ?? string.Empty);

            Console.ForegroundColor = currentForeground;
            Console.BackgroundColor = currentBackground;
            Console.OutputEncoding = currentEncoding;
        }

        public static void WriteLineColored(
            object? message,
            ConsoleColor foreground = ConsoleColor.Yellow,
            ConsoleColor background = ConsoleColor.Black
        )
        {
            WriteColored(message, foreground, background);
            Console.WriteLine();
        }

        public static void WriteColored(params Colored[] messages)
        {
            if (messages.Length > 0)
            {
                foreach (Colored message in messages)
                    WriteColored(message.Message, message.Foreground, message.Background);
            }
        }

        public static void WriteLineColored(params Colored[] messages)
        {
            WriteColored(messages);
            Console.WriteLine();
        }

        #endregion

        #region Остальные методы работы с консолью
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
        #endregion
    }
}
