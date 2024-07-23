using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8_2
{
    internal class Circle : Figure
    {
        private const double PI = 3.1415926535897931;
        public double Radius
        {
            get => _sides[0].Value;
            private set => _sides[0].Value = value;
        }

        public Circle(double radius)
        {
            _sides = [new FigureSide("Радиус", radius)];
        }

        public override string FigureName => "Окружность";

        public override double GetPerimeter() => 2 * PI * Radius;

        public override double GetSquare() => PI * Radius * Radius;

        public static Circle GetRandomFigure()
        {
            Random random = new Random();

            double radius = random.Next(0, 50);

            return new Circle(radius);
        }
    }
}
