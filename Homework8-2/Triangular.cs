using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;

namespace Homework8_2
{
    internal class Triangular : Figure
    {
        public double A
        {
            get => _sides[0].Value;
            private set => _sides[0].Value = value;
        }
        public double B
        {
            get => _sides[1].Value;
            private set => _sides[1].Value = value;
        }
        public double C
        {
            get => _sides[2].Value;
            private set => _sides[2].Value = value;
        }

        public Triangular(double a, double b, double c)
        {
            _sides = [new FigureSide("A", a), new FigureSide("B", b), new FigureSide("C", c)];

            if (!CheckExistance(a, b, c))
            {
                ConsoleUtility.WriteLineColored(
                    "Такой треугольник не существует (одна из сторон больше суммы двух других)!",
                    ConsoleColor.Red
                );
                ConsoleUtility.WriteLineColored(
                    "Будет создан треугольник со сторонами равными 5",
                    ConsoleColor.Yellow
                );

                A = B = C = 5;
            }
        }

        public override string FigureName => "Треугольник";

        public override double GetPerimeter() => A + B + C;

        public override double GetSquare()
        {
            double p = GetPerimeter() / 2;

            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        private static bool CheckExistance(double a, double b, double c) =>
            !(a >= b + c || b >= a + c || c >= b + a);

        public static Triangular GetRandomFigure()
        {
            Random random = new Random();
            double a,
                b,
                c;

            do
            {
                a = random.Next(1, 50);
                b = random.Next(1, 50);
                c = random.Next(1, 50);
            } while (!CheckExistance(a, b, c));

            return new Triangular(a, b, c);
        }
    }
}
