using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyHomeworkToolkit.ConsoleUtility;

namespace MyHomeworkToolkit.ObjectSelecting
{
    public static class ObjectSelector<TObject>
        where TObject : ISelectableObject
    {
        public static TObject? SelectFromList(List<TObject> list, Action predicateAction)
        {
            TObject? selectedObject = default;
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
                    ConsoleColor.DarkYellow
                );

                int i = 0;

                foreach (TObject item in list)
                {
                    if (i == selectedIndex)
                        WriteLineColored($"> {item.DisplayedName}", ConsoleColor.Green);
                    else
                        WriteLineColored(item.DisplayedName, ConsoleColor.Cyan);
                    i++;
                }

                bool isKeyCorrect;
                bool isObjectSelected = false;

                do
                {
                    isObjectSelected = ChangeSelectedIndex(
                        Console.ReadKey(true).Key,
                        out isKeyCorrect
                    );

                    if (isObjectSelected)
                        return selectedObject;
                } while (!isKeyCorrect);
            }

            bool ChangeSelectedIndex(ConsoleKey key, out bool isKeyCorrect)
            {
                isKeyCorrect = true;
                switch (key)
                {
                    case ConsoleKey.Escape:
                        selectedObject = default;
                        return true;
                    case ConsoleKey.Enter:
                        selectedObject = list.ElementAt(selectedIndex);
                        return true;
                    case ConsoleKey.DownArrow:
                        if (selectedIndex >= list.Count - 1)
                            selectedIndex = 0;
                        else
                            selectedIndex++;

                        //if (list.ElementAt(selectedIndex).DisplayedName == null)
                        if (list.ElementAt(selectedIndex) is SelectionSeparator)
                            ChangeSelectedIndex(ConsoleKey.DownArrow, out isKeyCorrect);

                        return false;
                    case ConsoleKey.UpArrow:
                        if (selectedIndex == 0)
                            selectedIndex = list.Count - 1;
                        else
                            selectedIndex--;

                        //if (list.ElementAt(selectedIndex).DisplayedName == null)
                        if (list.ElementAt(selectedIndex) is SelectionSeparator)
                            ChangeSelectedIndex(ConsoleKey.UpArrow, out isKeyCorrect);

                        return false;
                    default:
                        isKeyCorrect = false;
                        return false;
                }
            }
        }

        private static void ChangeSelectedIndex(ConsoleKey key) { }

        public static TObject? SelectFromList(List<TObject> list, string message) =>
            SelectFromList(list, () => DisplayMessage(message));

        public static TObject? SelectFromList(List<TObject> list) =>
            SelectFromList(list, "Выберите объект:");

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
