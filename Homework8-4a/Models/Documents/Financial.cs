using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;

namespace Homework8_4a.Models.Documents
{
    internal class Financial : Document
    {
        public override string Type => "Финансовая накладная";

        public double? Sum { get; private set; }

        public int? DepartmentId { get; private set; }

        public Financial(double? sum, int? departmentId, DateOnly creationDate)
            : base(creationDate)
        {
            Sum = sum;
            DepartmentId = departmentId;
        }

        public Financial(double? sum, int? departmentId)
            : this(sum, departmentId, DateOnly.FromDateTime(DateTime.Now)) { }

        public Financial()
            : this(null, null) { }

        public override void PrintInfo()
        {
            base.PrintInfo();

            if (Sum.HasValue)
                ConsoleUtility.WriteLineColored(
                    new Colored("Итоговая сумма за месяц: ", ConsoleColor.Cyan),
                    new Colored($"[{Sum}]", (Sum > 0) ? ConsoleColor.Green : ConsoleColor.Red)
                );
            else
                ConsoleUtility.WriteLineColored(
                    new Colored("Итоговая сумма за месяц: ", ConsoleColor.Cyan),
                    new Colored("[отсутствует]", ConsoleColor.Red)
                );

            if (DepartmentId.HasValue)
                ConsoleUtility.WriteLineColored(
                    new Colored("Код департамента: ", ConsoleColor.Cyan),
                    new Colored($"[{DepartmentId}]", ConsoleColor.Yellow)
                );
            else
                ConsoleUtility.WriteLineColored(
                    new Colored("Код департамента: ", ConsoleColor.Cyan),
                    new Colored("[отсутствует]", ConsoleColor.Red)
                );
        }
    }
}
