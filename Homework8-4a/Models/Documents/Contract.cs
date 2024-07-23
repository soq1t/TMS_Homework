using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;

namespace Homework8_4a.Models.Documents
{
    internal class Contract : Document
    {
        public override string Type => "Контракт";

        public string? Name { get; private set; }

        public DateOnly? ExpirationDate { get; private set; }

        public Contract(string? name, DateOnly? expirationDate, DateOnly creationDate)
            : base(creationDate)
        {
            Name = name;
            ExpirationDate = expirationDate;
        }

        public Contract(string? name, DateOnly? expirationDate)
            : this(name, expirationDate, DateOnly.FromDateTime(DateTime.Now)) { }

        public Contract()
            : this(null, null) { }

        public override void PrintInfo()
        {
            base.PrintInfo();

            if (Name != null)
                ConsoleUtility.WriteLineColored(
                    new Colored("Имя сотрудника: ", ConsoleColor.Cyan),
                    new Colored($"[{Name}]", ConsoleColor.Green)
                );
            else
                ConsoleUtility.WriteLineColored(
                    new Colored("Имя сотрудника: ", ConsoleColor.Cyan),
                    new Colored("[отсутствует]", ConsoleColor.Red)
                );

            if (ExpirationDate.HasValue)
                ConsoleUtility.WriteLineColored(
                    new Colored("Дата окончания контракта: ", ConsoleColor.Cyan),
                    new Colored(
                        $"[{ExpirationDate}]",
                        (ExpirationDate < DateOnly.FromDateTime(DateTime.Now))
                            ? ConsoleColor.Red
                            : ConsoleColor.Green
                    )
                );
            else
                ConsoleUtility.WriteLineColored(
                    new Colored("Дата окончания контракта: ", ConsoleColor.Cyan),
                    new Colored("[отсутствует]", ConsoleColor.Red)
                );
        }
    }
}
