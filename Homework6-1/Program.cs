using Homework6_1.Doctors;
using MyHomeworkToolkit;
using MyHomeworkToolkit.ObjectSelecting;

namespace Homework6_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitDoctors();
            InitPatients();
            InitActions();

            SelectAction();
        }

        #region Common Actions
        private static ActionSelector _actions = new ActionSelector();

        private static void InitActions()
        {
            _actions.AddAction("Действия с пациентами", SelectPatientActions);
            _actions.AddAction("Действия с врачами", SelectDoctorsActions);

            _actions.AddAction("Закрыть программу", CloseProgram);
        }

        private static void SelectAction()
        {
            _actions.SelectAction(Greetings);
            Console.WriteLine();

            ConsoleUtility.WriteLineColored(
                "Нажмите любую клавишу для продолжения",
                ConsoleColor.Yellow
            );
            Console.ReadKey(true);
            SelectAction();
        }

        private static void Greetings()
        {
            ConsoleUtility.WriteLineColored("Добро пожаловать в нашу клинику!", ConsoleColor.Cyan);
            Console.WriteLine();
            ConsoleUtility.WriteLineColored("Выберите желаемое действие:", ConsoleColor.Yellow);
        }

        private static void CloseProgram() => Environment.Exit(0);

        #endregion

        #region Patients
        private static ActionSelector _patientActions = new ActionSelector();
        private static List<Patient> _patients = new List<Patient>();

        private static void InitPatients()
        {
            _patients.Add(new Patient("Варфаломей", 25, "Болит ухо"));
            _patients.Add(new Patient("Антонина Петровна", 89, "Болит голова"));

            _patientActions.AddAction("Показать список пациентов", ShowPatients);
            _patientActions.AddAction("Записать нового пациента в клинику", AddPatient);
            _patientActions.AddAction("Выписать пациента из клиники", RemovePatient);
            _patientActions.AddAction("Вернуться на главную", SelectAction);
        }

        private static void SelectPatientActions()
        {
            _patientActions.SelectAction("Доступные действия с пациентами клиники:");
            Console.WriteLine();

            ConsoleUtility.WriteLineColored(
                "Нажмите любую клавишу для продолжения",
                ConsoleColor.Yellow
            );
            Console.ReadKey(true);
            SelectPatientActions();
        }

        private static void ShowPatients()
        {
            if (_patients.Count == 0)
            {
                ConsoleUtility.WriteLineColored(
                    "В клинике отсутствуют пациенты!",
                    ConsoleColor.Green
                );
            }
            else
            {
                ConsoleUtility.WriteLineColored(
                    "Список пациентов данной клиники:",
                    ConsoleColor.Yellow
                );
                Console.WriteLine();

                foreach (Patient patient in _patients)
                {
                    patient.Introduce();

                    if (patient != _patients.Last())
                        ConsoleUtility.WriteLineColored(
                            "--------------------------",
                            ConsoleColor.White
                        );
                }
            }
        }

        private static void AddPatient()
        {
            Console.Clear();
            ConsoleUtility.WriteLineColored(
                "Запись нового пациента в клинику",
                ConsoleColor.Yellow
            );
            Console.WriteLine();

            string name,
                diagnose;
            int age = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            do
            {
                Console.Write("Имя пациента: ");
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                    ConsoleUtility.WriteLineColored(
                        "Обязательно введите имя пациента!",
                        ConsoleColor.Red
                    );

                Console.WriteLine();
            } while (string.IsNullOrEmpty(name));

            do
            {
                Console.Write("Возраст пациента: ");
                Int32.TryParse(Console.ReadLine(), out age);

                if (age <= 0)
                    ConsoleUtility.WriteLineColored(
                        "Неверное значение возраста пациента!",
                        ConsoleColor.Red
                    );

                Console.WriteLine();
            } while (age == 0);

            do
            {
                Console.Write("Диагноз пациента: ");
                diagnose = Console.ReadLine();

                if (string.IsNullOrEmpty(diagnose))
                    ConsoleUtility.WriteLineColored(
                        "Обязательно введите диагноз пациента!",
                        ConsoleColor.Red
                    );

                Console.WriteLine();
            } while (string.IsNullOrEmpty(diagnose));

            Patient patien = new Patient(name, age, diagnose);

            Console.ResetColor();
            Console.Clear();

            ConsoleUtility.WriteLineColored("Новый пациент:", ConsoleColor.Yellow);
            patien.Introduce();
            _patients.Add(patien);
        }

        private static void RemovePatient()
        {
            Console.Clear();
            ConsoleUtility.WriteLineColored(
                "Выберите пациента, которого желаете выписать из клиники:",
                ConsoleColor.Yellow
            );

            Patient patient = ObjectSelector<Patient>.SelectFromList(_patients);

            if (patient != null)
            {
                _patients.Remove(patient);
                Console.Clear();
                ConsoleUtility.WriteLineColored(
                    $"Пациент \"{patient.Name}\" был успешно выписан из клиники!",
                    ConsoleColor.Green
                );
            }
        }

        #endregion

        #region Doctors
        private static List<Doctor> _doctors = new List<Doctor>();

        private static ActionSelector _doctorsActions = new ActionSelector();

        private static void InitDoctors()
        {
            _doctors.Add(new Therapist("Светлана", 22));
            _doctors.Add(new Surgeon("Анатолий", 41));
            _doctors.Add(new Dantist("Ирина", 18));

            _doctorsActions.AddAction("Показать список врачей", ShowDoctors);
            _doctorsActions.AddAction("Вернуться на главную", SelectAction);
        }

        private static void SelectDoctorsActions()
        {
            _doctorsActions.SelectAction("Доступные действия с врачами клиники:");
            Console.WriteLine();

            ConsoleUtility.WriteLineColored(
                "Нажмите любую клавишу для продолжения",
                ConsoleColor.Yellow
            );
            Console.ReadKey(true);
            SelectDoctorsActions();
        }

        private static void ShowDoctors()
        {
            if (_doctors.Count == 0)
            {
                ConsoleUtility.WriteLineColored(
                    "В клинике отсутствуют врачи! Надо срочно нанять кого-то",
                    ConsoleColor.Red
                );
            }
            else
            {
                ConsoleUtility.WriteLineColored(
                    "Список врачей данной клиники:",
                    ConsoleColor.Yellow
                );
                Console.WriteLine();

                foreach (Doctor doctor in _doctors)
                {
                    doctor.Introduce();

                    if (doctor != _doctors.Last())
                        ConsoleUtility.WriteLineColored(
                            "--------------------------",
                            ConsoleColor.White
                        );
                }
            }
        }

        private static void AddDoctor()
        {
            Console.Clear();
            ConsoleUtility.WriteLineColored("Режим найма нового врача", ConsoleColor.Yellow);
        }

        #endregion
    }
}
