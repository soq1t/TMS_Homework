using MyHomeworkToolkit;

namespace Homework8_2
{
    internal class Program
    {
        private static Figure[] _figures;

        static void Main(string[] args)
        {
            _figures =
            [
                Triangular.GetRandomFigure(),
                Rectangle.GetRandomFigure(),
                Circle.GetRandomFigure(),
                Rectangle.GetRandomFigure(),
                Triangular.GetRandomFigure(),
            ];

            double perimeterSum = 0;
            double squareSum = 0;
            foreach (Figure f in _figures)
            {
                f.PrintSides();

                f.PrintPerimeter();

                f.PrintSquare();

                perimeterSum += f.GetPerimeter();
                squareSum += f.GetSquare();

                ConsoleUtility.PressToContinue();
                if (f != _figures.Last())
                    Console.WriteLine();
            }

            Console.Clear();
            Figure.PrintSummarySquare();
            Figure.PrintSummaryPerimeter();
            ConsoleUtility.PressToContinue();
        }
    }
}
