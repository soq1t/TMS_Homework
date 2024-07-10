using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6_1.Doctors
{
    public class Dantist : Doctor
    {
        public Dantist(string name, int age, ConsoleColor color = ConsoleColor.Magenta)
            : base(name, age, "Зубной доктор", color) { }

        public override void PerformHealing()
        {
            Say("А что тут у нас? Любим сладенького поесть?");

            Action("С довольной ухмылкой берёт в руки стоматологическую дрель");
            Action("Кровожадно сверлит зубы несчастного пациента");

            Say("Вот и всё, больше не будете на конфеты налегать, хе-хе");
        }
    }
}
