using Homework13_1.Squad;
using MyHomeworkToolkit;
using MyHomeworkToolkit.ObjectSelecting;
using static MyHomeworkToolkit.ConsoleUtility;

namespace Homework13_1
{
    internal class Program
    {
        private static readonly ActionSelector _actions;

        static Program()
        {
            _actions = new ActionSelector();

            _actions.AddAction("Выбрать JSON файл", SelectJson);

            _actions.AddSeparator();
            _actions.AddExitProgramAction();
        }

        private static void SelectJson()
        {
            string dirPath =
                InputDataHandler.GetTextData(
                    "Введите адрес папки с входными данными\n(пустая строка - адрес по умолчанию)",
                    (str) => true
                ) ?? string.Empty;

            if (dirPath == string.Empty)
                dirPath = Directory.GetCurrentDirectory() + @"\input";

            if (CheckDirectoryExistance(dirPath))
            {
                DirectoryInfo inputDir = new DirectoryInfo(dirPath);
                FileInfo? deserializableFile = GetFile(inputDir);
                Console.Clear();

                if (deserializableFile != null)
                {
                    try
                    {
                        Squad.Squad? squad = SquadManager.DeserializeSquad(deserializableFile);
                        if (squad != null)
                        {
                            squad.PrintInfo();
                            PressToContinue();
                            string desicion =
                                ObjectSelector<TextOption>
                                    .SelectFromList(
                                        new List<TextOption>()
                                        {
                                            new TextOption("Да"),
                                            new TextOption("Нет")
                                        },
                                        "Хотите выгрузить данные о команде в XML формате?"
                                    )
                                    ?.DisplayedName ?? "Нет";

                            if (desicion == "Да")
                            {
                                SquadManager.SerializeSqauadToXml(squad);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        PrintError("Возникла ошибка:");
                        PrintError(ex.Message);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            _actions.SelectActionRepeated();
        }

        private static bool CheckDirectoryExistance(string dirPath)
        {
            if (!dirPath.Contains(":"))
            {
                PrintError("Введённая строка не является адресом к папке с входными данными!");
                return false;
            }

            try
            {
                bool isDirExists = Directory.Exists(dirPath);
                if (isDirExists)
                {
                    return true;
                }
                else
                {
                    PrintError("Такая папка не существует!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                PrintError("Ошибка входных данных:");
                PrintError($"{ex.Message}");
                return false;
            }
        }

        private static FileInfo? GetFile(DirectoryInfo dir)
        {
            List<FileInfo> files = dir.GetFiles()
                .Where(f => f.Name.ToLower().EndsWith(".json"))
                .ToList();

            if (files.Count == 0)
            {
                PrintError(
                    "В указанной папке отсутствуют файлы формата .json",
                    pressToContinue: true
                );
                return null;
            }
            else
            {
                List<TextOption> fileNames = new List<TextOption>();
                foreach (FileInfo file in files)
                {
                    fileNames.Add(new TextOption(file.Name));
                }

                TextOption? selectedFileName = ObjectSelector<TextOption>.SelectFromList(
                    fileNames,
                    "Выберите файл для десериализации:"
                );

                if (selectedFileName != null)
                {
                    return new FileInfo(dir.FullName + $"\\{selectedFileName.DisplayedName}");
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
