using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;
using MyHomeworkToolkit.ObjectSelecting;

namespace Homework7_2
{
    internal class CreditCard : ISelectableObject
    {
        private delegate bool MoneyOperation(double amount, bool displayInfoMessages);

        private static readonly CultureInfo _culture = new CultureInfo("en-US");

        private double _overdraft;

        private const string DefaultNumber = "1111 1111 1111 1111";
        public string Number { get; private set; }

        public string DisplayedName =>
            $"Номер карты: {Number}\nСумма на счёте: {string.Format(_culture, "{0:C2}", _money)}";

        private double _money;

        public CreditCard()
            : this(DefaultNumber) { }

        public CreditCard(string number)
            : this(number, 0) { }

        public CreditCard(string number, double money, double overdraft = 1000)
        {
            _overdraft = -Math.Abs(overdraft);

            if (!SetNumber(number, false))
            {
                ConsoleUtility.WriteLineColored(
                    "Неверное значение номера карты. Будет установлен стандартный номер",
                    ConsoleColor.Red
                );

                number = DefaultNumber;
            }

            if (money < overdraft)
            {
                ConsoleUtility.WriteLineColored(
                    "Указанная сумма превышает допустимый овердрафт! Будет установлено значение 0",
                    ConsoleColor.Red
                );

                money = 0;
            }
            else
            {
                _money = money;
            }

            PrintCardInfo();
        }

        public void PrintCardInfo()
        {
            ConsoleUtility.WriteColored("Номер карты: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteLineColored(Number, ConsoleColor.White);

            PrintMoney();

            ConsoleUtility.WriteColored("Допустимый овердрафт: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteLineColored(
                string.Format(_culture, "{0:C2}", Math.Abs(_overdraft)),
                ConsoleColor.Red
            );
        }

        #region Card Number Methods

        public static string GetRandomCardNumber()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 16; i++)
                stringBuilder.Append(random.Next(0, 10).ToString());

            return stringBuilder.ToString();
        }

        public void SetNumber()
        {
            string number;
            bool isSucceed = true;
            do
            {
                ConsoleUtility.WriteColored("Введите номер карты: ", ConsoleColor.Cyan);
                number = Console.ReadLine();

                isSucceed = SetNumber(number);
            } while (!isSucceed);
        }

        public bool SetNumber(string number, bool displayInfoMessages = true)
        {
            if (string.IsNullOrEmpty(number))
            {
                if (displayInfoMessages)
                    ErrorHandler.ShowError("Введите номер карты!");
                return false;
            }
            else
            {
                number = number.Replace(" ", string.Empty);

                foreach (char c in number)
                {
                    if (!char.IsDigit(c))
                    {
                        if (displayInfoMessages)
                            ErrorHandler.ShowError("Номер карты должен содержать только цифры!");
                        return false;
                    }
                }

                if (number.Length != 16)
                {
                    if (displayInfoMessages)
                        ErrorHandler.ShowError(
                            $"Номер карты должен состоять из 16 цифр (в указанном номере {number.Length} цифр)!"
                        );
                    return false;
                }

                Number = FormatNumber(number);

                if (displayInfoMessages)
                {
                    ConsoleUtility.WriteColored("Установленный номер карты: ", ConsoleColor.Cyan);
                    ConsoleUtility.WriteLineColored(Number, ConsoleColor.Green);
                }
                return true;
            }
        }

        private string FormatNumber(string input)
        {
            StringBuilder sb = new StringBuilder();

            int i = 1;
            foreach (char c in input)
            {
                sb.Append(c);

                if (i % 4 == 0)
                    sb.Append(' ');
                i++;
            }

            return sb.ToString().Trim();
        }
        #endregion

        #region Money Methods
        public void PrintMoney()
        {
            if (_money >= 0)
            {
                ConsoleUtility.WriteColored("Текущая сумма на счёте: ", ConsoleColor.Cyan);
                ConsoleUtility.WriteLineColored(
                    string.Format(_culture, "{0:C2}", _money),
                    ConsoleColor.Green
                );
            }
            else
            {
                ConsoleUtility.WriteColored(
                    "На счёте обнаружена залолженность: ",
                    ConsoleColor.Cyan
                );
                ConsoleUtility.WriteLineColored(
                    string.Format(_culture, "{0:C2}", Math.Abs(_money)),
                    ConsoleColor.Red
                );
            }
        }

        public bool AddMoney() => PerformMoneyOperation(AddMoney);

        public bool AddMoney(double amount, bool displayInfoMessages = true)
        {
            if (amount < 0)
            {
                if (displayInfoMessages)
                    ErrorHandler.ShowError("Количество не может быть отрицательным!");

                return false;
            }
            else
            {
                _money += amount;

                if (displayInfoMessages)
                {
                    ConsoleUtility.WriteColored($"Успешно добавлено ", ConsoleColor.Green);
                    ConsoleUtility.WriteColored(
                        string.Format(_culture, "{0:C2}", amount),
                        ConsoleColor.Cyan
                    );
                    ConsoleUtility.WriteLineColored($" на карту!", ConsoleColor.Green);
                }
                Console.WriteLine();
                PrintCardInfo();
                return true;
            }
        }

        public bool WithdrawMoney() => PerformMoneyOperation(WithdrawMoney);

        public bool WithdrawMoney(double amount, bool displayInfoMessages = true)
        {
            if (amount < 0)
            {
                if (displayInfoMessages)
                    ErrorHandler.ShowError("Количество не может быть отрицательным!");

                return false;
            }
            else
            {
                if (_money - amount < _overdraft)
                {
                    if (displayInfoMessages)
                        ErrorHandler.ShowError(
                            $"Невозможно снять такую сумму со счёта! Остаток ({_money - amount}) превысит допустимую сумму овердрафта ({_overdraft})"
                        );
                    return false;
                }
                else
                    _money -= amount;

                if (displayInfoMessages)
                {
                    ConsoleUtility.WriteColored($"Успешно снято ", ConsoleColor.Green);
                    ConsoleUtility.WriteColored(
                        string.Format(_culture, "{0:C2}", amount),
                        ConsoleColor.Cyan
                    );
                    ConsoleUtility.WriteLineColored($" с карты!", ConsoleColor.Green);
                }
                Console.WriteLine();
                PrintCardInfo();
                return true;
            }
        }

        private bool PerformMoneyOperation(MoneyOperation operation)
        {
            double amount;
            bool isSucceed = true;
            do
            {
                ConsoleUtility.WriteColored("Введите сумму: ", ConsoleColor.Cyan);
                isSucceed = double.TryParse(Console.ReadLine(), out amount);

                if (!isSucceed)
                {
                    ErrorHandler.ShowError("Неверное значение!");
                }
                else if (amount < 0)
                {
                    ErrorHandler.ShowError("Значение должно быть положительным!");
                    isSucceed = false;
                }
            } while (!isSucceed);

            return operation.Invoke(amount, displayInfoMessages: true);
        }
        #endregion
    }
}
