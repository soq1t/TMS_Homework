using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;
using MyHomeworkToolkit.ObjectSelecting;

namespace Homework8_4a.Models.Documents
{
    internal abstract class Document : ISelectableObject
    {
        private static int _counter = 0;
        public int Id { get; private set; }
        public DateOnly? CreationDate { get; private set; }
        public abstract string Type { get; }

        public string? DisplayedName => $"ID {Id}, [{Type}]. Creation date: {CreationDate}";

        public Document(DateOnly? creationDate)
        {
            Id = _counter++;
            CreationDate = creationDate;
        }

        protected Document()
            : this(null) { }

        public virtual void PrintInfo()
        {
            ConsoleUtility.WriteLineColored(
                new Colored("Вид документа: ", ConsoleColor.Cyan),
                new Colored($"[{Type}]", ConsoleColor.Yellow)
            );

            if (CreationDate.HasValue)
                ConsoleUtility.WriteLineColored(
                    new Colored("Дата создания: ", ConsoleColor.Cyan),
                    new Colored($"[{CreationDate}]", ConsoleColor.Yellow)
                );
            else
                ConsoleUtility.WriteLineColored(
                    new Colored("Дата создания: ", ConsoleColor.Cyan),
                    new Colored("[отсутствует]", ConsoleColor.Red)
                );
        }
    }
}
