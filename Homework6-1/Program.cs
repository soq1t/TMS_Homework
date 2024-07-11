using Homework6_1.Doctors;
using MyHomeworkToolkit;

namespace Homework6_1
{
    internal class Program
    {
        private static List<Doctor> _doctors = new List<Doctor>();
        private static List<Patient> _patients = new List<Patient>();

        private static ActionSelector _actions = new ActionSelector();

        static void Main(string[] args)
        {
            _doctors.Add(new Therapist("Светлана", 22));
            _doctors.Add(new Surgeon("Анатолий", 41));
            _doctors.Add(new Dantist("Ирина", 18));

            _patients.Add(new Patient("Варфаломей", 25, "Болит ухо"));
            _patients.Add(new Patient("Антонина Петровна", 89, "Болит голова"));

            _actions.AddAction("Показать список врачей", ShowDoctors);
            _actions.AddAction("Показать список пациентов", ShowPatients);
            _actions.AddAction("Закрыть программу", CloseProgram);

            SelectAction();
        }

        private static void SelectAction()
        {
            _actions.SelectAction();
            Console.ReadKey(true);
            SelectAction();
        }

        private static void CloseProgram() => Environment.Exit(0);

        private static void ShowDoctors() => _doctors.ForEach(d => d.Introduce());

        private static void ShowPatients() => _patients.ForEach(p => p.Introduce());
    }
}
