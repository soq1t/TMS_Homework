using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;

namespace Homework9_3
{
    internal abstract class Car : IVehicle
    {
        private int _fuel;

        private int _tankCapacity;

        protected int _velocity;

        private int _consumption;

        public Car(int initFuel, int consumption, int tankCapacity)
        {
            _velocity = 500;

            if (initFuel < 0)
                ConsoleUtility.PrintError(
                    "Количество топлива не может быть отрицательным! Будет установлено значение 0"
                );
            else
                _fuel = initFuel <= tankCapacity ? initFuel : tankCapacity;

            if (consumption <= 0)
            {
                ConsoleUtility.PrintError(
                    "Расход топлива должно быть положительным! Будет установлен расход в 5 л/км"
                );
                _consumption = 5;
            }
            else
                _consumption = consumption;

            _tankCapacity = tankCapacity;
        }

        public void Drive(int distance)
        {
            PrintFuel();
            ConsoleUtility.WriteLineColored(
                new Colored("Бензина хватит на "),
                new Colored(_fuel / _consumption, ConsoleColor.Blue),
                new Colored(" км")
            );
            for (int i = 1; i <= distance; i++)
            {
                if (_fuel - _consumption < 0)
                {
                    ConsoleUtility.WriteLineColored(
                        "Авто не может ехать т.к. закончился бензин",
                        ConsoleColor.Red
                    );
                    break;
                }
                _fuel -= _consumption;
                ConsoleUtility.WriteLineColored(
                    new Colored("Автомобиль проехал: "),
                    new Colored(i, ConsoleColor.Blue),
                    new Colored(" км")
                );
                Thread.Sleep(_velocity);
            }
        }

        public bool Refuel(int fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                ConsoleUtility.PrintError("Авто не может быть заправлено таким кол-вом топлива!");
                return false;
            }

            if (_fuel == _tankCapacity)
            {
                ConsoleUtility.WriteLineColored("Бак заполнен до краёв!");
                return false;
            }

            ConsoleUtility.WriteLineColored("Заправка автомобиля...");
            Thread.Sleep(300);
            for (int i = 1; i <= fuelAmount; i++)
            {
                if (_fuel == _tankCapacity)
                    break;

                ConsoleUtility.WriteLineColored(
                    new Colored("Залито: "),
                    new Colored(i, ConsoleColor.Blue),
                    new Colored(" л")
                );
                _fuel++;
                Thread.Sleep(50);
            }

            ConsoleUtility.WriteLineColored("Автомобиль был заправлен!", ConsoleColor.Green);
            PrintFuel();
            return true;
        }

        public void PrintFuel() =>
            ConsoleUtility.WriteLineColored(
                new Colored("Кол-во бензина в авто: ", ConsoleColor.Cyan),
                new Colored(_fuel, ConsoleColor.Green),
                new Colored(" л", ConsoleColor.Cyan)
            );
    }
}
