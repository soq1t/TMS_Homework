using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework6_1.Doctors;
using MyHomeworkToolkit;
using MyHomeworkToolkit.ObjectSelecting;

namespace Homework6_1
{
    public class HealingPlan : ISelectableObject
    {
        public int Code { get; private set; }
        public Doctor? AssignedDoctor { get; private set; }
        public Patient AssignedPatient { get; private set; }

        public string DisplayedName => $"План лечения пациента \"{AssignedPatient.Name}\"";

        public HealingPlan(Patient assignedPatient)
        {
            AssignedPatient = assignedPatient;
        }

        public void AssignDoctor(List<Doctor> doctors)
        {
            Console.Clear();
            ConsoleUtility.WriteLineColored(
                "Выбор плана лечения для пациента:",
                ConsoleColor.Yellow
            );
            AssignedPatient.Introduce();

            int code;
            bool isInputCorrect;

            Console.ForegroundColor = ConsoleColor.Green;
            do
            {
                Console.Write("Укажите код плана лечения: ");
                isInputCorrect = Int32.TryParse(Console.ReadLine(), out code);

                if (!isInputCorrect)
                {
                    ConsoleUtility.WriteLineColored(
                        "Введите корректный код лечения!",
                        ConsoleColor.Red
                    );
                    Console.WriteLine();
                }
            } while (!isInputCorrect);

            Code = code;
            List<Doctor> suitedDoctors = new List<Doctor>();

            switch (code)
            {
                case 1:
                    suitedDoctors = doctors.Where(d => d is Surgeon).ToList();
                    break;
                case 2:
                    suitedDoctors = doctors.Where(d => d is Dantist).ToList();
                    break;
                default:
                    suitedDoctors = doctors.Where(d => d is Therapist).ToList();
                    break;
            }

            if (suitedDoctors.Count == 0)
            {
                ConsoleUtility.WriteLineColored(
                    "Отсутствуют подходящие врачи для данного плана лечения!",
                    ConsoleColor.Red
                );
                Console.ReadKey(true);
            }
            else
            {
                Doctor doctor = ObjectSelector<Doctor>.SelectFromList(suitedDoctors);

                if (doctor != null)
                {
                    ConsoleUtility.WriteLineColored(
                        "Для данного пациента был назначен доктор:",
                        ConsoleColor.Green
                    );
                    doctor.Introduce();
                    AssignedDoctor = doctor;
                }
                else
                {
                    ConsoleUtility.WriteLineColored(
                        "Отмена назначения плана лечения!",
                        ConsoleColor.Red
                    );
                    ConsoleUtility.WriteLineColored(
                        "Нажмите любую клавишу для продолжения",
                        ConsoleColor.Red
                    );
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }

        public void Print()
        {
            if (AssignedDoctor == null)
            {
                ConsoleUtility.WriteLineColored(
                    $"План лечения пациента \"{AssignedPatient.Name}\" не назначен!",
                    ConsoleColor.Green
                );
            }
            else
            {
                ConsoleUtility.WriteLineColored($"Код плана лечения: {Code}", ConsoleColor.Yellow);
                ConsoleUtility.WriteLineColored($"Назначенный врач:", ConsoleColor.Yellow);
                AssignedDoctor.Introduce();
            }
        }

        public bool HealPatient()
        {
            if (AssignedDoctor == null)
            {
                ConsoleUtility.WriteLineColored(
                    $"План лечения не назначен! Лечение невозможно",
                    ConsoleColor.Red
                );
                return false;
            }
            else
            {
                ConsoleUtility.WriteLineColored(
                    $"Выполняется лечение пациента \"{AssignedPatient.Name}\"...",
                    ConsoleColor.Green
                );
                Console.WriteLine();
                AssignedDoctor.PerformHealing();

                Random random = new Random();

                bool isHealingSucceed = (random.Next(1, 11) <= 7) ? true : false;

                if (isHealingSucceed)
                {
                    AssignedPatient.SetDiagnose("Здоров как бык");
                    AssignedDoctor = null;

                    ConsoleUtility.WriteLineColored(
                        "Лечение выполнено успешно!",
                        ConsoleColor.Green
                    );
                }
                else
                {
                    ConsoleUtility.WriteLineColored(
                        "Не удалось вылечить пациента!",
                        ConsoleColor.Red
                    );
                }

                return isHealingSucceed;
            }
        }
    }
}
