using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkToolkit;

namespace Homework5
{
    public class Stringer
    {
        private string _data;
        private ActionSelector _exitActions;
        public ActionSelector StringActions { get; private set; }

        public Stringer(string DataStr, ActionSelector ExitActions)
        {
            _data = DataStr;
            _exitActions = ExitActions;

            StringActions = new ActionSelector();

            StringActions.AddAction(
                ConsoleKey.D1,
                "слова с максимальным количеством цифр",
                MaxDigitsWords
            );

            StringActions.AddAction(
                ConsoleKey.D0,
                "изменить строку / выйти из программы",
                ChangeData
            );
        }

        public void PerformStringAction(Action<object> action)
        {
            Console.Clear();
            Console.WriteLine("Ваша строка:");
            Console.WriteLine(_data);
            Console.WriteLine();

            action.Invoke(null);
        }

        #region Слова с максимальным количеством цифр
        private void MaxDigitsWords(object obj)
        {
            string noSignsString = GetNoSignsString(_data);

            List<string> words = noSignsString.Split(' ').ToList();

            int max = GetMaxDigitsAmount(words);

            List<string> maxDigitsWords = new List<string>();

            foreach (string word in words)
            {
                if (DigitsAmount(word) == max)
                    maxDigitsWords.Add(word);
            }

            Console.WriteLine($"Максимальное количество цифр в словах из данной строки: {max}");
            Console.WriteLine($"Количество таких слов в строке: {maxDigitsWords.Count}");
            Console.WriteLine();
            Console.WriteLine("Слова с данным количеством цифр:");

            maxDigitsWords.ForEach(Console.WriteLine);
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();

            PerformStringAction(StringActions.SelectAction());
        }

        private int DigitsAmount(string word)
        {
            int amount = 0;
            int result = 0;

            foreach (char c in word)
            {
                if (Int32.TryParse(c.ToString(), out result))
                    amount++;
            }

            return amount;
        }

        private int GetMaxDigitsAmount(List<string> words)
        {
            int maxDigitsAmount = 0;

            foreach (string word in words)
            {
                int digitsAmount = DigitsAmount(word);

                if (digitsAmount > maxDigitsAmount)
                    maxDigitsAmount = digitsAmount;
            }

            return maxDigitsAmount;
        }
        #endregion


        private void ChangeData(object obj) => _exitActions.SelectAction().Invoke(null);

        private string GetNoSignsString(string input)
        {
            string noSignsStr = _data;
            noSignsStr = noSignsStr.Replace(".", string.Empty);
            noSignsStr = noSignsStr.Replace(",", string.Empty);
            noSignsStr = noSignsStr.Replace("!", string.Empty);
            noSignsStr = noSignsStr.Replace("?", string.Empty);
            noSignsStr = noSignsStr.Replace(":", string.Empty);
            noSignsStr = noSignsStr.Replace(";", string.Empty);
            return noSignsStr;
        }
    }
}
