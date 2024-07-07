using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkToolkit;

namespace Homework5
{
    public static class DataUtility
    {
        private static string _result;

        public static string GetData()
        {
            ActionSelector actions = new ActionSelector();
            actions.AddAction("Прочитать строку из текстового файла", FromFile);
            actions.AddAction("Ввести строку в консоль", FromConsole);

            actions.SelectAction().Invoke(Directory.GetCurrentDirectory() + "\\input");

            return _result;

            //Console.Clear();
            //Console.WriteLine("Выберите режим работы:");
            //Console.WriteLine("1 - ввести строку в консоль");
            //Console.WriteLine("2 - прочитать строку из текстового файла");

            //while (true)
            //{
            //    ConsoleKey key = Console.ReadKey(true).Key;
            //    switch (key)
            //    {
            //        case ConsoleKey.D1:
            //            result = FromConsole();
            //        case ConsoleKey.D2:
            //            return FromFile(Directory.GetCurrentDirectory());
            //    }
            //}
        }

        private static void FromConsole(object obj = null)
        {
            string result = null;

            do
            {
                Console.Clear();
                Console.WriteLine("Ваша строка:");
                result = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(result))
                {
                    Console.Clear();
                    Console.WriteLine(
                        "Введите какие-нибудь данные)\nНажмите любую клавишу для продолжения..."
                    );
                    Console.ReadKey(true);
                }
            } while (string.IsNullOrWhiteSpace(result));

            Console.Clear();
            _result = result;
        }

        private static void FromFile(object obj)
        {
            string dirPath = (string)obj;
            DirectoryInfo searchDir = new DirectoryInfo(dirPath);

            List<FileInfo> txtFiles = searchDir
                .GetFiles()
                .Where(f => f.Name.EndsWith(".txt"))
                .ToList();
            if (txtFiles.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    "Не найден файл для чтения информации...\n\nНажмите любую клавишу для продолжения"
                );
                Console.ResetColor();
                Console.ReadKey(true);
                _result = null;
            }
            else if (txtFiles.Count == 1)
                _result = ReadFile(txtFiles.First());
            else
            {
                FileInfo selectedFile = null;
                int selectedPosition = 0;

                do
                {
                    bool isSelectedPos = false;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Выберите файл (стрелки вверх-вниз и Enter):");
                    Console.ResetColor();

                    int i = 0;
                    foreach (FileInfo file in txtFiles)
                    {
                        if (i == selectedPosition)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("> " + file.Name);
                            isSelectedPos = true;
                        }
                        else
                            Console.WriteLine(file.Name);

                        i++;
                        if (isSelectedPos)
                            Console.ResetColor();
                    }

                    ConsoleKey key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.Enter:
                            selectedFile = txtFiles[selectedPosition];
                            break;
                        case ConsoleKey.DownArrow:
                            if (selectedPosition >= txtFiles.Count - 1)
                                selectedPosition = 0;
                            else
                                selectedPosition++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (selectedPosition > 0)
                                selectedPosition--;
                            else
                                selectedPosition = txtFiles.Count - 1;
                            break;
                    }
                } while (selectedFile == null);

                _result = ReadFile(selectedFile);
            }
        }

        private static string ReadFile(FileInfo file)
        {
            TextReader reader = new StreamReader(file.FullName);
            return reader.ReadToEnd();
        }
    }
}
