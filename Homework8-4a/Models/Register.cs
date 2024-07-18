using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework8_4a.Interfaces;
using Homework8_4a.Models.Documents;
using MyHomeworkToolkit;
using MyHomeworkToolkit.ObjectSelecting;

namespace Homework8_4a.Models
{
    internal class Register : IRegister, ISelectableObject
    {
        private static int _registersCounter = 0;

        private int _registerId;
        private int _counter = 0;
        private readonly Document[] _documents;

        public string? DisplayedName => $"Реестр №{_registerId}";

        public Register()
        {
            _registerId = _registersCounter++;
            _documents = new Document[10];
        }

        public bool AddDocument(Document document)
        {
            if (!_documents.Contains(document))
            {
                _documents[_counter++] = document;
                ConsoleUtility.WriteLineColored(
                    new Colored("[Документ]", ConsoleColor.Blue),
                    new Colored(" был успешно добавлен в реестр!", ConsoleColor.Cyan)
                );
                return true;
            }
            else
            {
                ConsoleUtility.WriteLineColored(
                    new Colored("Указанный ", ConsoleColor.Red),
                    new Colored("[Документ]", ConsoleColor.Blue),
                    new Colored(" уже находится в данном реестре!", ConsoleColor.Red)
                );
                return false;
            }
        }

        public bool PrintDocumentInfo()
        {
            if (_documents.Any(d => d != null))
            {
                Document? document = ObjectSelector<Document>.SelectFromList(
                    _documents.Where(d => d != null).ToList(),
                    "Выберите документ из списка:"
                );
                Console.WriteLine();
                document?.PrintInfo();

                return document != null;
            }
            else
            {
                ConsoleUtility.WriteLineColored(
                    "В данном реестре отсутствуют документы!",
                    ConsoleColor.Red
                );
                return false;
            }
        }

        public void PrintRegisterInfo()
        {
            ConsoleUtility.WriteLineColored(
                new Colored("Реестр №", ConsoleColor.Yellow),
                new Colored(_registerId, ConsoleColor.Green)
            );
            ConsoleUtility.WriteLineColored(
                new Colored("Количество документов в реестре: ", ConsoleColor.Cyan),
                new Colored(_documents.Where(d => d != null).Count(), ConsoleColor.Green)
            );
        }
    }
}
