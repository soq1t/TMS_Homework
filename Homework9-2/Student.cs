using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9_2
{
    internal class Student : Person
    {
        private double _laziness;

        private string _diligence
        {
            get
            {
                if (_laziness < 0.3)
                    return "Очень ленивый";
                else if (_laziness < 0.7)
                    return "Средне-трудящийся";
                else
                    return "Прилежный";
            }
        }

        public Student(string name, int age)
            : base(name, age)
        {
            Random random = new Random();
            _laziness = random.NextDouble();
            PrintStudentDiligence();
        }

        public Student(string name)
            : base(name)
        {
            Random random = new Random();
            _laziness = random.NextDouble();
            PrintStudentDiligence();
        }

        public Student(int age)
            : base(age)
        {
            Random random = new Random();
            _laziness = random.NextDouble();
            PrintStudentDiligence();
        }

        public Student()
        {
            Random random = new Random();
            _laziness = random.NextDouble();
            PrintStudentDiligence();
        }

        public void PrintStudentDiligence() => Say($"Я - {_diligence.ToLower()} ученик!");

        public void Study()
        {
            Random random = new Random();

            if (random.NextDouble() >= _laziness)
                Say("Я учусь!");
            else
                Say("Ай что-то лень... Не хочу учиться)");
        }

        public void ShowAge() => Say($"мой возраст: {Age} лет!");
    }
}
