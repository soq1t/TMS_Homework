using MyHomeworkToolkit;

namespace Homework9_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SportsCar sportsCar = new SportsCar();

            sportsCar.Refuel(
                InputDataHandler.GetIntData(
                    "Сколько топлива хотите заправить в спорткар?",
                    InputDataHandler.MoreThanZeroChecker
                )
            );
            ConsoleUtility.PressToContinue();
            Console.Clear();

            sportsCar.Drive(
                InputDataHandler.GetIntData(
                    "Сколько километров хотите проехать?",
                    InputDataHandler.MoreThanZeroChecker
                )
            );
            ConsoleUtility.PressToContinue();
            Console.Clear();
            Truck truck = new Truck();

            truck.Refuel(
                InputDataHandler.GetIntData(
                    "Сколько топлива хотите заправить в грузовик?",
                    InputDataHandler.MoreThanZeroChecker
                )
            );
            ConsoleUtility.PressToContinue();
            Console.Clear();
            truck.Drive(
                InputDataHandler.GetIntData(
                    "Сколько километров хотите проехать?",
                    InputDataHandler.MoreThanZeroChecker
                )
            );
            ConsoleUtility.PressToContinue();
        }
    }
}
