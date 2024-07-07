using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    public static class DataUtility
    {
        public static string GetData()
        {
            Console.Clear();
            Console.WriteLine("Выберите режим работы:");
            Console.WriteLine("1 - ввести строку в консоль");
            Console.WriteLine("2 - прочитать строку из текстового файла");

            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        return FromConsole();
                    case ConsoleKey.D2:
                        return FromFile(Directory.GetCurrentDirectory());
                }
            }
        }

        private static string FromConsole()
        {
            string result = null;

            do
            {
                Console.Clear();
                result = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine("Введите какие-нибудь данные)");
                    Thread.Sleep(1500);
                }
            } while (string.IsNullOrWhiteSpace(result));

            return result;
        }

        private static string FromFile(string dirPath)
        {
            DirectoryInfo searchDir = new DirectoryInfo(dirPath);

            List<FileInfo> txtFiles = searchDir
                .GetFiles()
                .Where(f => f.Name.EndsWith(".txt"))
                .ToList();
            if (txtFiles.Count == 0)
            {
                Console.WriteLine(
                    "Не найден файл для чтения информации...\n\nНажмите любую клавишу для продолжения"
                );
                Console.ReadKey(true);
                return null;
            }
            else if (txtFiles.Count == 1)
                return ReadFile(txtFiles.First());
            else
            {
                FileInfo selectedFile = null;
                int selectedPosition = 0;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Выберите файл (стрелки вверх-вниз и Enter:");

                    int i = 0;
                    foreach (FileInfo file in txtFiles)
                    {
                        if (i == selectedPosition)
                            Console.WriteLine("> " + file.Name);
                        else
                            Console.WriteLine(file.Name);

                        i++;
                    }

                    ConsoleKey key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.Enter:
                            selectedFile = txtFiles[selectedPosition];
                            break;
                        case ConsoleKey.DownArrow:
                            selectedPosition =
                                (selectedPosition <= txtFiles.Count - 1)
                                    ? txtFiles.Count - 1
                                    : selectedPosition++;

                            break;
                        case ConsoleKey.UpArrow:
                            selectedPosition = (selectedPosition >= 0) ? 0 : selectedPosition--;
                            break;
                    }
                } while (selectedFile == null);

                return ReadFile(selectedFile);
            }
        }

        private static string ReadFile(FileInfo file)
        {
            TextReader reader = new StreamReader(file.FullName);
            return reader.ReadToEnd();
        }
    }
}
