using System;
using System.Text;
using MyHomeworkToolkit;

namespace Homework6
{
    internal class Program
    {
        private static ActionSelector _actions = new ActionSelector();

        private static Dictionary<string, long> _abonents = new Dictionary<string, long>()
        {
            { "Билл Гейтс", GetRandomNumber() },
            { "Павел Дуров", GetRandomNumber() },
            { "Степан", GetRandomNumber() },
            { "Андрей", GetRandomNumber() },
            { "Василиса", GetRandomNumber() },
            { "Тим Кук", GetRandomNumber() },
        };

        static void Main(string[] args)
        {
            _actions.AddAction("Конструкторы класса Phone", SimplePhones);
            _actions.AddAction("Метод ReceiveCall", CallReciever);
            _actions.AddAction("Метод ReceiveCall с перегрузкой", CallRecieverOverloaded);
            _actions.AddAction("Метод SendMessage", SendMessage);

            _actions.AddAction("Завершить программу", Exit, true);

            List<Phone> phones = new List<Phone>()
            {
                new Phone() { Model = "Samsung Galaxy S24 Ultra", Weight = 354 },
                new Phone(GetRandomNumber(), "IPhone 15 Pro"),
                new Phone(GetRandomNumber(), "Google Pixel 8 Pro", 312),
            };

            _actions.SelectAction("Выберите действие:").Invoke(phones);
        }

        #region Служебные методы
        private static long GetRandomNumber()
        {
            Random random = new Random();
            List<string> codes = new List<string>() { "29", "25", "33", "44" };

            StringBuilder number = new StringBuilder("375");

            number.Append(codes.ElementAt(random.Next(0, 4)));

            for (int i = 0; i < 7; i++)
            {
                number.Append(random.Next(0, 10).ToString());
            }

            return long.Parse(number.ToString());
        }

        private static void NextStep(List<Phone> phones)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ResetColor();
            Console.ReadKey(true);
            Console.Clear();
            _actions.SelectAction("Выберите действие:").Invoke(phones);
        }

        private static void SetRandomColor()
        {
            Random random = new Random();
            int colorIndex;
            ConsoleColor color;

            do
            {
                colorIndex = random.Next(1, 15);
                color = (ConsoleColor)Enum.ToObject(typeof(ConsoleColor), colorIndex);
            } while (colorIndex == 14 || colorIndex == 12 || color == Console.ForegroundColor);

            Console.ForegroundColor = color;
        }

        private static void SystemMessage(string message)
        {
            ConsoleColor current = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.WriteLine();
            Console.ForegroundColor = current;
        }

        private static void Exit(object obj) => Environment.Exit(0);

        #endregion

        #region Методы по ДЗ

        private static void SimplePhones(object obj)
        {
            List<Phone> phones = (List<Phone>)obj;
            Console.Clear();

            SystemMessage(
                "Создание 3 экземпляров Phone, вывод на консоль значений их переменных (с использованием разных конструкторов)"
            );

            int i = 1;
            foreach (Phone phone in phones)
            {
                SetRandomColor();

                Console.WriteLine($"Phone №{i++}:");
                Console.WriteLine($"Модель - {phone.Model}");
                Console.WriteLine($"Номер - {phone.GetNumber()}");
                Console.WriteLine($"Вес - {phone.FormattedWeight}");
                Console.WriteLine();
            }

            NextStep(phones);
        }

        private static void CallReciever(object obj)
        {
            List<Phone> phones = (List<Phone>)obj;
            Console.Clear();

            SystemMessage("Метод ReceiveCall");

            Random random = new Random();
            foreach (Phone phone in phones)
            {
                SetRandomColor();
                int abonentIndex = random.Next(0, _abonents.Count);

                Console.WriteLine($"Текущий телефон: {phone.Model}.");
                phone.ReceiveCall(_abonents.ElementAt(abonentIndex).Key);
                Console.WriteLine();
            }

            NextStep(phones);
        }

        private static void CallRecieverOverloaded(object obj)
        {
            List<Phone> phones = (List<Phone>)obj;
            Console.Clear();

            SystemMessage("Метод ReceiveCall с перегрузкой");

            Random random = new Random();
            foreach (Phone phone in phones)
            {
                SetRandomColor();
                int abonentIndex = random.Next(0, _abonents.Count);

                Console.WriteLine($"Текущий телефон: {phone.Model}.");
                phone.ReceiveCall(
                    _abonents.ElementAt(abonentIndex).Key,
                    _abonents.ElementAt(abonentIndex).Value
                );
                Console.WriteLine();
            }

            NextStep(phones);
        }

        private static void SendMessage(object obj)
        {
            List<Phone> phones = (List<Phone>)obj;
            Console.Clear();
            SystemMessage("Метод SendMessage");

            Random random = new Random();

            SetRandomColor();
            Console.WriteLine($"Текущий телефон: {phones[0]}");
            phones[0].SendMessage(GetRandomNumber(), GetRandomNumber());
            Console.WriteLine();

            SetRandomColor();
            Console.WriteLine($"Текущий телефон: {phones[1]}");
            phones[0]
                .SendMessage(
                    GetRandomNumber(),
                    GetRandomNumber(),
                    GetRandomNumber(),
                    GetRandomNumber()
                );
            Console.WriteLine();

            SetRandomColor();
            Console.WriteLine($"Текущий телефон: {phones[2]}");
            phones[0].SendMessage(GetRandomNumber());
            Console.WriteLine();

            NextStep(phones);
        }

        #endregion
    }
}
