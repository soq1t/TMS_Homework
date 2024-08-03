using MyHomeworkToolkit;
using MyHomeworkToolkit.ObjectSelecting;

namespace Homework8_1
{
    internal class Program
    {
        private static ActionSelector _actions;
        private static List<Animal> _animals;

        static Program()
        {
            _animals = new List<Animal>() { new Dog("Шарик"), new Dog("Жучка"), new Dog("Барбос") };

            _actions = new ActionSelector();

            _actions.AddAction("Поменять кличку животному", RenameAnimal);
            _actions.AddAction("Покормить животное", FeedAnimal);

            _actions.AddSeparator();
            _actions.AddAction("Забрать животное из приюта", GetAnimal);
            _actions.AddAction("Отдать животное в приют", AddAnimal);

            _actions.AddSeparator();
            _actions.AddExitProgramAction();
        }

        static void Main(string[] args)
        {
            _actions.SelectAction(PrintMessage);
        }

        #region Actions
        private static void PrintMessage()
        {
            ConsoleUtility.WriteLineColored("Добро пожаловать в наш приют!", ConsoleColor.Magenta);
            if (_animals.Count > 0)
            {
                ConsoleUtility.WriteLineColored("В приюте содержатся:", ConsoleColor.Yellow);

                foreach (var animal in _animals)
                {
                    if (animal is Dog)
                        ConsoleUtility.WriteLineColored("Собака", ConsoleColor.Blue);

                    animal.GetName();

                    //if (animal != _animals.Last())
                    //    Console.WriteLine();
                }
            }
            else
                ConsoleUtility.WriteLineColored(
                    "В данный момент в приюте нет животных!",
                    ConsoleColor.Yellow
                );

            Console.WriteLine();
            ConsoleUtility.WriteLineColored(
                "Выберите желаемое действие с животным:",
                ConsoleColor.Yellow
            );
        }

        private static void RenameAnimal()
        {
            Animal animal = ObjectSelector<Animal>.SelectFromList(
                _animals,
                "Кому вы хотите сменить кличку?"
            );

            if (animal != null)
            {
                animal.SetName();
            }
            else
            {
                Console.WriteLine();
                ConsoleUtility.WriteLineColored(
                    "Вы не выбрали никакого животного!",
                    ConsoleColor.Yellow
                );
            }
        }

        private static void FeedAnimal()
        {
            Animal animal = ObjectSelector<Animal>.SelectFromList(
                _animals,
                "Кого вы хотите покормить?"
            );

            if (animal != null)
            {
                ConsoleUtility.WriteColored("Чем вы хотите накормить ", ConsoleColor.Yellow);
                ConsoleUtility.WriteColored($"[{animal.Name}]", ConsoleColor.Green);
                ConsoleUtility.WriteLineColored("?", ConsoleColor.Yellow);
                ConsoleUtility.WriteLineColored(
                    "[Enter] - покормить сухим кормом",
                    ConsoleColor.Yellow
                );
                string? food = Console.ReadLine();

                if (string.IsNullOrEmpty(food))
                    animal.Eat();
                else
                    animal.Eat(food);
            }
            else
            {
                Console.WriteLine();
                ConsoleUtility.WriteLineColored(
                    "Вы не выбрали никакого животного!",
                    ConsoleColor.Yellow
                );
            }
        }

        private static void GetAnimal()
        {
            Animal animal = ObjectSelector<Animal>.SelectFromList(
                _animals,
                "Кого вы хотите забрать из приюта?"
            );

            if (animal != null)
            {
                ConsoleUtility.WriteColored($"[{animal.Name}]", ConsoleColor.Green);
                ConsoleUtility.WriteLineColored(
                    " будет рад оказаться в новой семье!",
                    ConsoleColor.Yellow
                );
                _animals.Remove(animal);
            }
        }

        private static void AddAnimal()
        {
            string name = InputDataHandler.GetTextData(
                "Кого вы хотите отдать в приют?\n(введите кличку собаки)"
            );

            Dog dog = new Dog(name);

            _animals.Add(dog);

            ConsoleUtility.WriteColored("Теперь ", ConsoleColor.Yellow);
            ConsoleUtility.WriteColored($"[{name}]", ConsoleColor.Green);
            ConsoleUtility.WriteLineColored(" живёт в приюте :(", ConsoleColor.Yellow);
        }
        #endregion
    }
}
