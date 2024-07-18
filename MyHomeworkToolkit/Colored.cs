using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeworkToolkit
{
    public class Colored
    {
        internal object Message { get; private set; }
        internal ConsoleColor Foreground { get; private set; }
        internal ConsoleColor Background { get; private set; }

        public Colored(
            object message,
            ConsoleColor foreground = ConsoleColor.Yellow,
            ConsoleColor background = ConsoleColor.Black
        )
        {
            Message = message;
            Foreground = foreground;
            Background = background;
        }
    }
}
