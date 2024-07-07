using System.Diagnostics;
using HomeworkToolkit;

namespace Homework5
{
    internal class Program
    {
        private static ActionSelector _initActions = new ActionSelector();

        static void Main(string[] args)
        {
            _initActions.AddAction("Начать работу со строкой", BeginProgram);
            _initActions.AddAction("Выход из программы", ExitProgram);

            _initActions.SelectAction().Invoke(null);
        }

        private static void ExitProgram(object obj) => Environment.Exit(0);

        private static void BeginProgram(object obj)
        {
            string dataString = DataUtility.GetData();

            if (dataString == null)
                _initActions.SelectAction().Invoke(null);

            Stringer stringer = new Stringer(dataString, _initActions);

            stringer.PerformStringAction(
                stringer.StringActions.SelectAction($"Ваша строка:\n{dataString}")
            );
        }
    }
}
