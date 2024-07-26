using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;

namespace Homework9_1
{
    internal class Debt
    {
        private double _balance;
        public double Balance
        {
            get => _balance;
            private set => _balance = value;
        }

        private double _interestRate;
        public double InterestRate
        {
            get => _interestRate;
            private set
            {
                if (value <= 1)
                {
                    ConsoleUtility.WriteLineColored(
                        "Процентная ставка должна быть > 1!",
                        ConsoleColor.Red
                    );
                }
                else
                    _interestRate = value;
            }
        }

        public Debt(double initialBalance, double initialInterestRate)
        {
            _balance = initialBalance;
            _interestRate = initialInterestRate;
        }

        public void PrintBalance() =>
            ConsoleUtility.WriteLineColored(
                new Colored("Баланс составляет: ", ConsoleColor.Cyan),
                new Colored(
                    string.Format("{0:C2}", Balance),
                    Balance > 0 ? ConsoleColor.Green : ConsoleColor.Red
                )
            );

        void Wait(int years = 1)
        {
            for (int i = 0; i < years; i++)
            {
                Balance *= InterestRate;
            }
        }
    }
}
