using MyHomeworkToolkit;

namespace Homework9_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Анатолий", 25);
            person.Greet();
            Console.WriteLine();

            Student student = new Student("Анфиса", 0);
            student.SetAge(19);
            student.Greet();
            student.ShowAge();
            Console.WriteLine();

            Teacher teacher = new Teacher("Вадим", 45);
            teacher.Greet();
            Console.WriteLine();
            ConsoleUtility.WriteLineColored(
                "   Начало занятия   ",
                ConsoleColor.White,
                ConsoleColor.DarkBlue
            );
            teacher.Explain();
            student.Study();

            ConsoleUtility.PressToContinue();
        }
    }
}
