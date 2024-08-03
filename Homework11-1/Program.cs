using MyHomeworkToolkit;

namespace Homework11_1
{
    internal class Program
    {
        private static readonly ActionSelector _actions;

        private static readonly ComparablePair<int, int>[] _pairs;

        static Program()
        {
            _pairs = new ComparablePair<int, int>[2];
            _actions = new ActionSelector();

            _actions.AddAction("Задать пару 1", () => SetPair(0));
            _actions.AddAction("Задать пару 2", () => SetPair(1));
            _actions.AddAction("Сравнить пары", ComparePairs);
            _actions.AddSeparator();
            _actions.AddExitProgramAction();
        }

        private static void ComparePairs()
        {
            if (_pairs[0] == null || _pairs[1] == null)
            {
                ConsoleUtility.PrintError(
                    "Одна из пар не задана! Невозможно произвести сравнение пар!"
                );
            }
            else
            {
                int compareResult = _pairs[0].CompareTo(_pairs[1]);

                switch (compareResult)
                {
                    case -1:
                        ConsoleUtility.WriteLineColored(
                            "Пара чисел №2 больше чем пара чисел №1!",
                            ConsoleColor.Green
                        );
                        break;
                    case 0:
                        ConsoleUtility.WriteLineColored("Пары чисел равны", ConsoleColor.Green);
                        break;
                    case 1:
                        ConsoleUtility.WriteLineColored(
                            "Пара чисел №1 больше чем пара чисел №2!",
                            ConsoleColor.Green
                        );
                        break;
                }
            }
        }

        private static void SetPair(int pairIndex)
        {
            int valueT = InputDataHandler.GetIntData("Введите первое число из пары");
            int valueU = InputDataHandler.GetIntData("Введите второе число из пары");

            _pairs[pairIndex] = new ComparablePair<int, int>(valueT, valueU);

            Console.Clear();
            ConsoleUtility.WriteLineColored(
                new Colored("Создана пара чисел "),
                new Colored(valueT, ConsoleColor.Green),
                new Colored(" и "),
                new Colored(valueU, ConsoleColor.Green),
                new Colored(".")
            );
            ConsoleUtility.PressToContinue();
        }

        static void Main(string[] args)
        {
            _actions.SelectActionRepeated(PrintMessage);
        }

        private static void PrintMessage()
        {
            for (int i = 0; i < _pairs.Length; i++)
            {
                ConsoleUtility.WriteLineColored($"Пара чисел №{i + 1}:");

                if (_pairs[i] == null)
                {
                    ConsoleUtility.WriteLineColored("Пара не задана!", ConsoleColor.Red);
                }
                else
                {
                    ConsoleUtility.WriteLineColored(
                        new Colored("Значение A: ", ConsoleColor.Cyan),
                        new Colored(_pairs[i].ValueT, ConsoleColor.Green)
                    );
                    ConsoleUtility.WriteLineColored(
                        new Colored("Значение B: ", ConsoleColor.Cyan),
                        new Colored(_pairs[i].ValueU, ConsoleColor.Green)
                    );
                }

                Console.WriteLine();
            }

            ConsoleUtility.WriteLineColored("Выберите следующее действие:");
        }
    }
}
