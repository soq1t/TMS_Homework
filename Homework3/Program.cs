namespace Homework3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Получаем объект с введёнными пользователем числами
            MathOperations operations = GetInputNumbers();

            MathActions(operations);
        }

        private static MathOperations GetInputNumbers()
        {
            Console.Clear();
            double x = DataUtility.GetDouble("X");
            Console.WriteLine();
            double y = DataUtility.GetDouble("Y");

            return new MathOperations(x, y);
        }

        private static Dictionary<ConsoleKey, string> _actionsMapper = new Dictionary<
            ConsoleKey,
            string
        >()
        {
            { ConsoleKey.D1, "Сложение" },
            { ConsoleKey.D2, "Вычитание" },
            { ConsoleKey.D3, "Умножение" },
            { ConsoleKey.D4, "Деление" },
            { ConsoleKey.D5, "Вычисление процентного соотношения" },
            { ConsoleKey.D6, "Вычисление квадратного корня" },
            { ConsoleKey.D9, "Изменить числа X и Y" },
            { ConsoleKey.D0, "Завершить программу" }
        };

        private static void MathActions(MathOperations operations)
        {
            double x = operations.X;
            double y = operations.Y;

            Console.Clear();
            Console.WriteLine("Ваши числа:");
            Console.WriteLine($"X = {x}\nY = {y}");

            Console.WriteLine();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine($"1 - {_actionsMapper[ConsoleKey.D1]}");
            Console.WriteLine($"2 - {_actionsMapper[ConsoleKey.D2]}");
            Console.WriteLine($"3 - {_actionsMapper[ConsoleKey.D3]}");
            Console.WriteLine($"4 - {_actionsMapper[ConsoleKey.D4]}");
            Console.WriteLine($"5 - {_actionsMapper[ConsoleKey.D5]}");
            Console.WriteLine($"6 - {_actionsMapper[ConsoleKey.D6]}");
            Console.WriteLine();
            Console.WriteLine($"9 - {_actionsMapper[ConsoleKey.D9]}");
            Console.WriteLine($"0 - {_actionsMapper[ConsoleKey.D0]}");

            // Флажок, который указывает, правильная ли была нажата клавиша выбора действия
            bool isKeyCorrect;

            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // По умолчанию считаем, что клавиша верна
                isKeyCorrect = true;

                switch (key.Key)
                {
                    case ConsoleKey.D0:
                        return;

                    case ConsoleKey.D9:
                        MathActions(GetInputNumbers());
                        break;

                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Ваши числа:");
                        Console.WriteLine($"X = {x}\nY = {y}");
                        Console.WriteLine();

                        Console.WriteLine($"Выбранная операция: {_actionsMapper[key.Key]}");

                        Console.WriteLine($"{x} + {y} = {operations.Sum()}");

                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey(true);
                        MathActions(operations);
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Ваши числа:");
                        Console.WriteLine($"X = {x}\nY = {y}");
                        Console.WriteLine();

                        Console.WriteLine($"Выбранная операция: {_actionsMapper[key.Key]}");

                        Console.WriteLine(
                            $"{x} - {y} = {operations.Substraction(OperationMode.FirstX)}"
                        );
                        Console.WriteLine(
                            $"{y} - {x} = {operations.Substraction(OperationMode.FirstY)}"
                        );

                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey(true);
                        MathActions(operations);
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("Ваши числа:");
                        Console.WriteLine($"X = {x}\nY = {y}");
                        Console.WriteLine();

                        Console.WriteLine($"Выбранная операция: {_actionsMapper[key.Key]}");

                        Console.WriteLine($"{x} * {y} = {operations.Multiplication()}");

                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey(true);
                        MathActions(operations);
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("Ваши числа:");
                        Console.WriteLine($"X = {x}\nY = {y}");
                        Console.WriteLine();

                        Console.WriteLine($"Выбранная операция: {_actionsMapper[key.Key]}");

                        if (y == 0)
                            Console.WriteLine($"Невозможно поделить X на Y, т.к. Y = 0");
                        else
                            Console.WriteLine(
                                $"{x} / {y} = {operations.Division(OperationMode.FirstX)}"
                            );

                        if (x == 0)
                            Console.WriteLine($"Невозможно поделить Y на X, т.к. X = 0");
                        else
                            Console.WriteLine(
                                $"{x} / {y} = {operations.Division(OperationMode.FirstY)}"
                            );

                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey(true);
                        MathActions(operations);
                        break;

                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.WriteLine("Ваши числа:");
                        Console.WriteLine($"X = {x}\nY = {y}");
                        Console.WriteLine();

                        Console.WriteLine($"Выбранная операция: {_actionsMapper[key.Key]}");

                        if (x == 0)
                            Console.WriteLine(
                                $"Невозможно определить, какой процент составляет Y составялет от X (т.к. X = 0)"
                            );
                        else
                            Console.WriteLine(
                                $"Число {y} составляет {operations.Percent(OperationMode.FirstX)}% от числа {x}"
                            );

                        if (y == 0)
                            Console.WriteLine(
                                $"Невозможно определить, какой процент составляет X составялет от Y (т.к. Y = 0)"
                            );
                        else
                            Console.WriteLine(
                                $"Число {x} составляет {operations.Percent(OperationMode.FirstY)}% от числа {y}"
                            );

                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey(true);
                        MathActions(operations);
                        break;

                    case ConsoleKey.D6:
                        Console.Clear();
                        Console.WriteLine("Ваши числа:");
                        Console.WriteLine($"X = {x}\nY = {y}");
                        Console.WriteLine();

                        Console.WriteLine($"Выбранная операция: {_actionsMapper[key.Key]}");

                        Console.WriteLine(
                            $"Квадратный корень числа {x} равен {operations.SquareRoot(OperationMode.FirstX)}"
                        );
                        Console.WriteLine(
                            $"Квадратный корень числа {y} равен {operations.SquareRoot(OperationMode.FirstY)}"
                        );

                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey(true);
                        MathActions(operations);
                        break;

                    default:
                        // Если ни один из кейсов не прошёл, значи клавиша нажата неверная. Запрашиваем клавишу от пользователя заново
                        isKeyCorrect = false;
                        break;
                }
            } while (!isKeyCorrect);
        }
    }
}
