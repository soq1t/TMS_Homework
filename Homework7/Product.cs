using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;
using MyHomeworkToolkit.ObjectSelecting;

namespace Homework7
{
    internal class Product : ISelectableObject
    {
        private static readonly CultureInfo culture = new CultureInfo("en-US");
        private static int _idAssigner = 0;
        public int Id { get; private set; }
        public string Name { get; private set; }

        private double _price = 0;
        public double Price => _price;
        public string FormattedPrice => string.Format(culture, "{0:C2}", _price);

        private int _amount = 0;
        public int Amount => _amount;
        public string FormattedAmount => $"{_amount} шт.";

        public string DisplayedName =>
            $"ID: {Id} - {Name}, Стоимость: {FormattedPrice}, Кол-во: {FormattedAmount}";

        public Product(string name, double price, int amount)
        {
            Id = _idAssigner++;
            Name = name;

            SetPrice(price);
            AddAmount(amount);
        }

        public Product(string name, int amount)
            : this(name, 0, amount) { }

        public Product(string name, double price)
            : this(name, price, 0) { }

        public Product(string name)
            : this(name, 0) { }

        public void PrintInfo()
        {
            ConsoleUtility.WriteColored("ID: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteColored(Id.ToString(), ConsoleColor.Green);
            Console.Write("\t");

            ConsoleUtility.WriteColored("Наименование: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteColored(Name, ConsoleColor.Green);
            Console.Write("\t");

            ConsoleUtility.WriteColored("Кол-во: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteColored(FormattedAmount, ConsoleColor.Green);
            Console.Write("\t");

            ConsoleUtility.WriteColored("Стоимость: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteColored(FormattedPrice, ConsoleColor.Green);
            Console.WriteLine();
        }

        #region Amount Operations
        public void PrintAmount()
        {
            ConsoleUtility.WriteColored("Кол-во товара ", ConsoleColor.Cyan);
            ConsoleUtility.WriteColored($"[{Name}]", ConsoleColor.Green);
            ConsoleUtility.WriteColored(": ", ConsoleColor.Cyan);
            ConsoleUtility.WriteLineColored(FormattedAmount, ConsoleColor.Green);
        }

        public bool AddAmount(int amount)
        {
            if (amount < 0)
            {
                ConsoleUtility.WriteLineColored($"Введите положительное число!", ConsoleColor.Red);
                Console.ReadKey(true);
                return false;
            }
            else
            {
                _amount += amount;
                ConsoleUtility.WriteLineColored(
                    $"Вы добавили {amount} шт. товара [{Name}]!",
                    ConsoleColor.Green
                );

                PrintAmount();
                return true;
            }
        }

        public bool RemoveAmount(int amount)
        {
            if (_amount < 0)
            {
                ConsoleUtility.WriteLineColored($"Введите положительное число!", ConsoleColor.Red);
                Console.ReadKey(true);
                return false;
            }
            else
            {
                if (amount > _amount)
                {
                    ConsoleUtility.WriteLineColored(
                        $"Не хватает товара [{Name}]!",
                        ConsoleColor.Red
                    );
                }
                else
                {
                    _amount -= amount;
                    ConsoleUtility.WriteLineColored(
                        $"Вы убрали {amount} шт. товара [{Name}]!",
                        ConsoleColor.Green
                    );
                }

                PrintAmount();
                return true;
            }
        }

        public bool SetAmount(int amount)
        {
            if (amount < 0)
            {
                ConsoleUtility.WriteLineColored($"Введите положительное число!", ConsoleColor.Red);
                Console.ReadKey(true);
                return false;
            }
            else
            {
                _amount = amount;
                PrintAmount();
                return true;
            }
        }
        #endregion

        #region Price Operations
        public void PrintPrice() =>
            ConsoleUtility.WriteLineColored(
                $"Стоимость [{Name}] - {FormattedPrice}",
                ConsoleColor.Cyan
            );

        public bool SetPrice(double price)
        {
            if (price < 0)
            {
                ConsoleUtility.WriteLineColored(
                    "Значение не может быть отрицательным!",
                    ConsoleColor.Red
                );
                Console.ReadKey(true);
                return false;
            }
            else
            {
                _price = price;
                ConsoleUtility.WriteLineColored(
                    $"Вы успешно изменили стоимость [{Name}]",
                    ConsoleColor.Green
                );
                PrintPrice();
                return true;
            }
        }
        #endregion
    }
}
