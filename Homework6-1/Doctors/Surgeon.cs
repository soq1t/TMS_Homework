using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6_1.Doctors
{
    public class Surgeon : Doctor
    {
        public Surgeon(string name, int age, ConsoleColor color = ConsoleColor.Red)
            : base(name, age, "Хирург", color) { }

        public override void PerformHealing()
        {
            Say("Какой ужас! Требуется срочная ампутация!!");
            Action("Надевает перчатки");
            Action("Берёт и накладывает жгут");
            Action("Берёт пилу");
            Action("Отрезает ногу");
            Action("Вытирает пот со лба");
            Say("Дело сделано, можно и по чаю!");
        }
    }
}
