using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6_1.Doctors
{
    public class Therapist : Doctor
    {
        public Therapist(string name, ConsoleColor color = ConsoleColor.Green)
            : base(name, "Терапевт", color) { }

        public override void PerformHealing()
        {
            Say("Начинаю осмотр!");

            Action("проверяет уши");
            Action("проверяет нос");
            Action("стучит по коленям");

            Say("Всё отлично! Можете идти");
        }
    }
}
