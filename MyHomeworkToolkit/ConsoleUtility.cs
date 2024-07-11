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
    }
}
