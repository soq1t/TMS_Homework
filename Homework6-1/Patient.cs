using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework6_1.Doctors;
using MyHomeworkToolkit;

namespace Homework6_1
{
    public class Patient : Person
    {
        private string _diagnose;
        private HealingPlan _healingPlan;
        public bool IsHealingPlanAssigned => _healingPlan.AssignedDoctor != null;
        public override string DisplayedName => $"{Name},Возраст: {Age}\nДиагноз: {_diagnose}";

        public Patient(
            string name,
            int age,
            string diagnose = "Здоров как бык",
            ConsoleColor color = ConsoleColor.Cyan
        )
            : base(name, age, color)
        {
            _diagnose = diagnose;
            _healingPlan = new HealingPlan(this);
        }

        public override void Introduce()
        {
            base.Introduce();
            ConsoleColor current = Console.ForegroundColor;
            Console.ForegroundColor = _color;

            Console.WriteLine($"Пациент клиники");
            Console.ForegroundColor = current;

            CheckDiagnose();
            Console.WriteLine();
        }

        public void Heal()
        {
            _healingPlan.HealPatient();
        }

        public void SetDiagnose(string diagnose) => _diagnose = diagnose;

        public void CheckDiagnose() =>
            ConsoleUtility.WriteLineColored($"Диагноз пациента: {_diagnose}", _color);

        public HealingPlan AssignHealingPlan(List<Doctor> doctors)
        {
            _healingPlan = new HealingPlan(this);
            _healingPlan.AssignDoctor(doctors);

            return _healingPlan;
        }

        public void CheckHealingPlan() => _healingPlan.Print();
    }
}
