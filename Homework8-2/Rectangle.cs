using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;

namespace Homework8_2
{
    internal class Rectangle : Figure
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
        public override string FigureName => "Прямоугольник";

        public Rectangle(double a, double b)
        {
            _sides = [new FigureSide("A", a), new FigureSide("B", b)];
        }

        public override double GetPerimeter() => (A + B) * 2;

        public override double GetSquare() => A * B;

        public static Rectangle GetRandomFigure()
        {
            Random rnd = new Random();
            double a,
                b;

            a = rnd.Next(1, 50);
            b = rnd.Next(1, 50);

            return new Rectangle(a, b);
        }
    }
}
