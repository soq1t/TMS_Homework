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
            StringActions.AddAction("Замена цифр на слова", DigitsReplacer);
            StringActions.AddAction(
                "Сортировка предложений (безэмоциональные -> восклицательные -> вопросительные",
                StringSorting
            );

            StringActions.AddAction("Изменить строку / выйти из программы", ChangeData, true);
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

            if (max == 0)
            {
                Console.WriteLine("В данной строке нет слов, содержащих цифры!");
            }
            else
            {
                Console.WriteLine($"Максимальное количество цифр в словах из данной строки: {max}");
                Console.WriteLine($"Количество таких слов в строке: {maxDigitsWords.Count}");
                Console.WriteLine();
                Console.WriteLine("Слова с данным количеством цифр:");

                maxDigitsWords.ForEach(Console.WriteLine);
            }

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

        #region Замена цифр на буквы
        private static Dictionary<char, string> _digitReplaceMap = new Dictionary<char, string>()
        {
            { '0', "ноль" },
            { '1', "один" },
            { '2', "два" },
            { '3', "три" },
            { '4', "четыре" },
            { '5', "пять" },
            { '6', "шесть" },
            { '7', "семь" },
            { '8', "восемь" },
            { '9', "девять" },
        };

        private void DigitsReplacer(object obj)
        {
            int replaceCounter = 0;

            StringBuilder newString = new StringBuilder();

            for (int i = 0; i < _data.Length; i++)
            {
                char c = _data[i];
                if (_digitReplaceMap.ContainsKey(c))
                {
                    replaceCounter++;

                    if (i != 0 && newString.ToString().Last() != ' ')
                        newString.Append(" ");

                    newString.Append(_digitReplaceMap[c].ToUpper());

                    if (i != _data.Length - 1 && _data[i + 1] != ' ')
                        newString.Append(" ");
                }
                else
                    newString.Append(c);
            }

            if (replaceCounter == 0)
                Console.WriteLine("В данной строке не было цифр. Строка не изменилась!");
            else
            {
                Console.WriteLine($"Количество замен в строке составило: {replaceCounter}");
                Console.WriteLine($"Получившийся результат:\n{newString}");
            }

            CancelAction();
        }
        #endregion

        #region Восклицательные и вопросительные предложения

        private void StringSorting(object obj)
        {
            List<string> exclamations = new List<string>();
            List<string> interrogations = new List<string>();
            List<StringBuilder> commons = new List<StringBuilder>();

            StringBuilder currentSentence = new StringBuilder();

            foreach (char c in _data)
            {
                if (c == '.' && commons.Count > 0)
                {
                    commons.Last().Append(c);
                }
                else
                {
                    currentSentence.Append(c);

                    switch (c)
                    {
                        case '.':
                            commons.Add(new StringBuilder(currentSentence.ToString()));
                            currentSentence.Clear();
                            break;
                        case '!':
                            exclamations.Add(currentSentence.ToString());
                            currentSentence.Clear();
                            break;
                        case '?':
                            interrogations.Add(currentSentence.ToString());
                            currentSentence.Clear();
                            break;
                    }
                }
            }

            if (commons.Count == 0)
                Console.WriteLine("Безэмоциональные предложения отсутствуют((");
            else
            {
                Console.WriteLine($"Безэмоциональные предложения ({commons.Count} шт):");
                commons.ForEach(s => Console.WriteLine(s.ToString().Trim()));
            }

            Console.WriteLine();

            if (exclamations.Count == 0)
                Console.WriteLine("Восклицательные предложения отсутствуют((");
            else
            {
                Console.WriteLine($"Восклицательные предложения ({exclamations.Count} шт):");
                exclamations.ForEach(s => Console.WriteLine(s.Trim()));
            }

            Console.WriteLine();

            if (interrogations.Count == 0)
                Console.WriteLine("Вопросительные предложения отсутствуют((");
            else
            {
                Console.WriteLine($"Вопросительные предложения ({interrogations.Count} шт):");
                interrogations.ForEach(s => Console.WriteLine(s.Trim()));
            }

            CancelAction();
        }

        #endregion

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
