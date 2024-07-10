using Homework6_1.Doctors;

namespace Homework6_1
{
    internal class Program
    {
        private static Doctor[] _doctors;
        private static Patient[] _patients;

        static void Main(string[] args)
        {
            _doctors =
            [
                new Therapist("Светлана", 22),
                new Surgeon("Анатолий", 41),
                new Dantist("Ирина", 18)
            ];

            _patients =
            [
                new Patient("Варфаломей", 25, "Болит ухо"),
                new Patient("Антонина Петровна", 89, "Болит голова")
            ];

            _patients[0].Introduce();
            _patients[0].Heal();
            _patients[0].CheckDiagnose();
        }
    }
}
