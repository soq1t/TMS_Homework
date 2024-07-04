namespace Homework4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ActionSelection(CreateMatrix());
        }

        private static Matrix CreateMatrix()
        {
            int x,
                y = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Введите кол-во строк в матрице:");
                string input = Console.ReadLine();

                Int32.TryParse(input, out x);
                if (x <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Вы ввели неверное значение!");
                    Thread.Sleep(2500);
                }
            } while (x <= 0);

            do
            {
                Console.Clear();
                Console.WriteLine("Введите кол-во столбцов в матрице:");
                string input = Console.ReadLine();

                Int32.TryParse(input, out y);
                if (y <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Вы ввели неверное значение!");
                    Thread.Sleep(2500);
                }
            } while (y <= 0);

            int[][] array = new int[x][];

            Console.Clear();
            Console.WriteLine("Заполнить матрицу рандомными числами от -10 до 10?");
            Console.WriteLine("Enter - да");
            bool isRandomFilling = (Console.ReadKey().Key == ConsoleKey.Enter) ? true : false;

            for (int i = 0; i < x; i++)
            {
                array[i] = new int[y];
                for (int j = 0; j < y; j++)
                {
                    if (isRandomFilling)
                        array[i][j] = new Random().Next(-10, 11);
                    else
                    {
                        bool isSucceed = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(
                                $"Введите {j + 1}-ое число {i + 1}-ой строки матрицы:"
                            );

                            string input = Console.ReadLine();

                            isSucceed = Int32.TryParse(input, out array[i][j]);

                            if (!isSucceed)
                            {
                                Console.Clear();
                                Console.WriteLine("Вы ввели неверное значение!");
                                Thread.Sleep(4000);
                            }
                        } while (!isSucceed);
                    }
                }
            }

            return new Matrix(array);
        }

        private static void ActionSelection(Matrix matrix)
        {
            Console.Clear();
            Console.WriteLine("Текущая матрица:");
            matrix.Print();

            Console.WriteLine();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - вывести кол-во положительных чисел матрицы");
            Console.WriteLine("2 - вывести кол-во положительных чисел матрицы");
            Console.WriteLine();
            Console.WriteLine("3 - отсортировать матрицу по возростанию (построчно)");
            Console.WriteLine("4 - отсортировать матрицу по убыванию (построчно)");
            Console.WriteLine();
            Console.WriteLine("5 - инвертировать матрицу (построчно)");
            Console.WriteLine();
            Console.WriteLine("9 - задать новую матрицу");
            Console.WriteLine("0 - завершить программу");

            bool isKeyCorrect = true;
            do
            {
                isKeyCorrect = true;
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D0:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.D9:
                        ActionSelection(CreateMatrix());
                        break;
                    case ConsoleKey.D1:
                        Console.Clear();
                        matrix.PrintAmount(AmountMode.Positive);
                        Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey(true);

                        ActionSelection(matrix);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        matrix.PrintAmount(AmountMode.Negative);
                        Console.Write("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey(true);

                        ActionSelection(matrix);
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        matrix.PrintSorted(SortMode.Ascending);
                        Console.Write("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey(true);

                        ActionSelection(matrix);
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        matrix.PrintSorted(SortMode.Descending);
                        Console.Write("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey(true);

                        ActionSelection(matrix);
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        matrix.PrintInverted();
                        Console.Write("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey(true);

                        ActionSelection(matrix);
                        break;
                    default:
                        isKeyCorrect = false;
                        break;
                }
            } while (!isKeyCorrect);
        }
    }
}
