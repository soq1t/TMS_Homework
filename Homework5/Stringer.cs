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
        private List<string> _words;
        private ActionSelector _exitActions;
        public ActionSelector StringActions { get; private set; }

        public Stringer(string DataStr, ActionSelector ExitActions)
        {
            _data = DataStr;
            string noSigns = GetNoSignsString(DataStr);

            _words = noSigns.Split(" ").ToList();

            _exitActions = ExitActions;

            StringActions = new ActionSelector();

            StringActions.AddAction("Слова с максимальным количеством цифр", MaxDigitsWords);
            StringActions.AddAction("Саммое длинное слово", TheLongestWord);

            StringActions.AddAction("Изменить строку / выйти из программы", ChangeData);
        }

        public void PerformStringAction(Action<object> action)
        {
            Console.Clear();
            Console.WriteLine($"Ваша строка:\n{_data}");
            Console.WriteLine();

            action.Invoke(null);
        }

        private void CancelAction()
        {
            Console.WriteLine();
            Console.Write("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
            PerformStringAction(StringActions.SelectAction($"Ваша строка:\n{_data}"));
        }

        #region Саммое длинное слово
        private void TheLongestWord(object obj)
        {
            Dictionary<string, int> theLongestWords = GetLongestWordsList(_words);
            int wordLength = theLongestWords.First().Key.Length;

            Console.WriteLine($"Количество букв в саммом длинном слове строки: {wordLength}");
            if (theLongestWords.Count == 1)
            {
                Console.WriteLine(
                    $"Это слово: {theLongestWords.First().Key}\t\tОно встречается {theLongestWords.First().Value} раз!"
                );
            }
            else
            {
                Console.WriteLine("В данной строке таких слов несколько:");
                foreach (KeyValuePair<string, int> word in theLongestWords)
                {
                    Console.WriteLine($"Слово: {word.Key}\t\tОно встречается {word.Value} раз");
                }
            }

            CancelAction();
        }

        private string GetTheLongestWord(List<string> words)
        {
            string result = string.Empty;

            foreach (string word in words)
            {
                if (word.Length > result.Length)
                    result = word;
            }

            return result;
        }

        private Dictionary<string, int> GetLongestWordsList(List<string> words)
        {
            int wordLength = GetTheLongestWord(words).Length;

            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (word.Length == wordLength)
                {
                    if (result.ContainsKey(word))
                        result[word]++;
                    else
                        result.Add(word, 1);
                }
            }

            return result;
        }
        #endregion

        #region Слова с максимальным количеством цифр
        private void MaxDigitsWords(object obj)
        {
            int max = GetMaxDigitsAmount(_words);

            List<string> maxDigitsWords = new List<string>();

            foreach (string word in _words)
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

            CancelAction();
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
            noSignsStr = noSignsStr.Replace(")", string.Empty);
            noSignsStr = noSignsStr.Replace("(", string.Empty);
            return noSignsStr;
        }
    }
}
