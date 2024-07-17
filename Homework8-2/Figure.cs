using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;

namespace Homework8_2
{
    internal abstract class Figure
    {
        private static List<Figure> _createdFigures = new List<Figure>();

        public abstract string FigureName { get; }

        protected FigureSide[] _sides;

        protected Figure()
        {
            _createdFigures.Add(this);
        }

        public static void PrintSummaryPerimeter()
        {
            ConsoleUtility.WriteColored(
                "Сумма периметров всех фигур составляет: ",
                ConsoleColor.Cyan
            );

            double sum = 0;
            foreach (Figure f in _createdFigures)
                sum += f.GetPerimeter();

            ConsoleUtility.WriteColored(sum.ToString(), ConsoleColor.Yellow);
            ConsoleUtility.WriteLineColored(" кв. см.", ConsoleColor.Cyan);
        }

        public static void PrintSummarySquare()
        {
            ConsoleUtility.WriteColored(
                "Сумма площадей всех фигур составляет: ",
                ConsoleColor.Cyan
            );

            double sum = 0;
            foreach (Figure f in _createdFigures)
                sum += f.GetSquare();

            ConsoleUtility.WriteColored(sum.ToString(), ConsoleColor.Yellow);
            ConsoleUtility.WriteLineColored(" куб. см.", ConsoleColor.Cyan);
        }

        protected void PrintFigureName()
        {
            ConsoleUtility.WriteColored("Фигура: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteLineColored($"[{FigureName}]", ConsoleColor.Blue);
        }

        public void PrintSides()
        {
            PrintFigureName();
            foreach (var side in _sides)
            {
                ConsoleUtility.WriteColored("Сторона ", ConsoleColor.Cyan);
                ConsoleUtility.WriteColored($"[{side.Name}]", ConsoleColor.Green);
                ConsoleUtility.WriteColored(": ", ConsoleColor.Cyan);
                ConsoleUtility.WriteLineColored(side.Value.ToString(), ConsoleColor.Yellow);
            }
        }

        public abstract double GetPerimeter();

        public void PrintPerimeter()
        {
            ConsoleUtility.WriteColored("Периметр фигуры ", ConsoleColor.Cyan);
            ConsoleUtility.WriteColored($"[{FigureName}]", ConsoleColor.Blue);
            ConsoleUtility.WriteColored(" равен: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteColored(GetPerimeter().ToString(), ConsoleColor.Yellow);
            ConsoleUtility.WriteLineColored(" кв. см.", ConsoleColor.Cyan);
        }

        public abstract double GetSquare();

        public void PrintSquare()
        {
            ConsoleUtility.WriteColored("Площадь фигуры ", ConsoleColor.Cyan);
            ConsoleUtility.WriteColored($"[{FigureName}]", ConsoleColor.Blue);
            ConsoleUtility.WriteColored(" равна: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteColored(GetSquare().ToString(), ConsoleColor.Yellow);
            ConsoleUtility.WriteLineColored(" куб. см.", ConsoleColor.Cyan);
        }
    }
}
