using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyHomeworkToolkit.ConsoleUtility;

namespace MyHomeworkToolkit.ObjectSelecting
{
    public static class ObjectSelector<T>
        where T : ISelectableObject
    {
        public static T SelectFromList(List<T> list, Action predicateAction)
        {
            Console.Clear();

            if (list.Count == 0)
            {
                WriteLineColored("Список объектов пуст!", ConsoleColor.Red);
                return default;
            }

            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                predicateAction?.Invoke();

                WriteLineColored(
                    "[Стрелки вверх - вниз] - Навигация\n[Enter] - Выбор объекта\n[ESC] - Отменить",
                    ConsoleColor.Yellow
                );

                int i = 0;

                foreach (T item in list)
                {
                    if (i == selectedIndex)
                        WriteLineColored($"> {item.DisplayedName}", ConsoleColor.Green);
                    else
                        WriteLineColored(item.DisplayedName, ConsoleColor.Cyan);
                    i++;
                }

                ConsoleKey key;
                bool isKeyCorrect;
                do
                {
                    isKeyCorrect = true;
                    key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.Escape:
                            return default;
                        case ConsoleKey.Enter:
                            return list.ElementAt(selectedIndex);
                        case ConsoleKey.DownArrow:
                            if (selectedIndex >= list.Count - 1)
                                selectedIndex = 0;
                            else
                                selectedIndex++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (selectedIndex == 0)
                                selectedIndex = list.Count - 1;
                            else
                                selectedIndex--;
                            break;
                        default:
                            isKeyCorrect = false;
                            break;
                    }
                } while (!isKeyCorrect);
            }
        }

        public static T SelectFromList(List<T> list, string message) =>
            SelectFromList(list, () => DisplayMessage(message));

        public static T SelectFromList(List<T> list) => SelectFromList(list, "Выберите объект:");

        private static void DisplayMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                WriteLineColored(message, ConsoleColor.Yellow);
                Console.WriteLine();
            }
        }
    }
}
