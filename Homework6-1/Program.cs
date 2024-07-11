using System.Xml.Linq;
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
            InitHealingPlans();
            InitActions();

            SelectAction();
        }

        #region Common Actions
        private static ActionSelector _actions = new ActionSelector();

        private static void InitActions()
        {
            _actions.AddAction("Действия с пациентами", SelectPatientActions);
            _actions.AddAction("Действия с врачами", SelectDoctorsActions);
            _actions.AddAction("Планы лечения пациентов", SelectHealingActions);

            _actions.AddAction("Закрыть программу", CloseProgram);
        }

        private static void SelectAction()
        {
            Console.ResetColor();
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
            ConsoleUtility.WriteColored(
                "В данный момент в клинике работает врачей: ",
                ConsoleColor.Cyan
            );
            ConsoleUtility.WriteLineColored(
                _doctors.Count.ToString(),
                (_doctors.Count > 0) ? ConsoleColor.Green : ConsoleColor.Red
            );

            ConsoleUtility.WriteColored("Пациентов в клинике: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteLineColored(
                _patients.Count.ToString(),
                (_patients.Count > 0) ? ConsoleColor.Green : ConsoleColor.Red
            );

            ConsoleUtility.WriteColored(
                "Назначенных планов лечения пациентам: ",
                ConsoleColor.Cyan
            );
            ConsoleUtility.WriteLineColored(
                _healingPlans.Count.ToString(),
                (_healingPlans.Count > 0) ? ConsoleColor.Green : ConsoleColor.Red
            );

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
            _patients.Add(new Patient("Гоша", 15, "Перелом ноги"));
            _patients.Add(new Patient("Сергей", 20, "Отвалилась пломба"));

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

        private static void HealingPlanMessage()
        {
            ConsoleUtility.WriteLineColored(
                "Назначение плана лечения пациенту",
                ConsoleColor.Yellow
            );
            Console.WriteLine();
            ConsoleUtility.WriteLineColored("Выберите пациента:", ConsoleColor.Yellow);
        }

        #endregion

        #region Doctors
        private static List<Doctor> _doctors = new List<Doctor>();

        private static ActionSelector _doctorsActions = new ActionSelector();

        private static List<TextOption> _doctorTypes = new List<TextOption>()
        {
            new TextOption("Хирург"),
            new TextOption("Зубной врач"),
            new TextOption("Терапевт")
        };

        private static void InitDoctors()
        {
            _doctors.Add(new Therapist("Светлана", 22));
            _doctors.Add(new Therapist("Алексей", 28));

            _doctors.Add(new Surgeon("Анатолий", 41));

            _doctors.Add(new Dantist("Ирина", 18));
            _doctors.Add(new Dantist("Руслан", 29));
            _doctors.Add(new Dantist("Степан", 31));

            _doctorsActions.AddAction("Показать список врачей", ShowDoctors);
            _doctorsActions.AddAction("Нанять нового врача", AddDoctor);
            _doctorsActions.AddAction("Уволить врача", RemoveDoctor);
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

            TextOption doctorType;
            string name;
            int age;

            do
            {
                doctorType = ObjectSelector<TextOption>.SelectFromList(
                    _doctorTypes,
                    "Выберите профессию нового врача:"
                );

                if (doctorType == null)
                {
                    Console.Clear();
                    ConsoleUtility.WriteLineColored(
                        "Нужно указать профессию нового врача!",
                        ConsoleColor.Red
                    );
                    Console.ReadKey(true);
                }
            } while (doctorType == null);

            Console.ForegroundColor = ConsoleColor.Green;
            do
            {
                Console.Write("Имя врача: ");
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                    ConsoleUtility.WriteLineColored(
                        "Обязательно введите имя врача!",
                        ConsoleColor.Red
                    );

                Console.WriteLine();
            } while (string.IsNullOrEmpty(name));

            do
            {
                Console.Write("Возраст врача: ");
                Int32.TryParse(Console.ReadLine(), out age);

                if (age <= 0)
                    ConsoleUtility.WriteLineColored(
                        "Неверное значение возраста врача!",
                        ConsoleColor.Red
                    );

                Console.WriteLine();
            } while (age == 0);

            Doctor doctor;

            if (doctorType.DisplayedName == "Хирург")
                doctor = new Surgeon(name, age);
            else if (doctorType.DisplayedName == "Зубной врач")
                doctor = new Dantist(name, age);
            else
                doctor = new Therapist(name, age);

            Console.Clear();
            Console.ResetColor();
            ConsoleUtility.WriteLineColored("Данные нового врача:", ConsoleColor.Green);
            doctor.Introduce();
            _doctors.Add(doctor);
        }

        private static void RemoveDoctor()
        {
            Console.Clear();
            ConsoleUtility.WriteLineColored(
                "Выберите врача, которого желаете уволить из клиники:",
                ConsoleColor.Yellow
            );

            Doctor doctor = ObjectSelector<Doctor>.SelectFromList(_doctors);

            if (doctor != null)
            {
                _doctors.Remove(doctor);
                Console.Clear();
                ConsoleUtility.WriteLineColored(
                    $"[{doctor.Type}] \"{doctor.Name}\" был успешно уволен из клиники!",
                    ConsoleColor.Green
                );
            }
        }

        #endregion

        #region Healing Plans
        private static List<HealingPlan> _healingPlans = new List<HealingPlan>();

        private static ActionSelector _healingActions = new ActionSelector();

        private static void InitHealingPlans()
        {
            _healingActions.AddAction("Назначить план лечения пациенту", AssignHealingPlan);
            _healingActions.AddAction("Показать план лечения пациента", CheckPatientsHealingPlan);
            _healingActions.AddAction("Начать лечение", PerformHealingPlan);
            _healingActions.AddAction("Вернуться на главную", SelectAction);
        }

        private static void SelectHealingActions()
        {
            _healingActions.SelectAction("Доступные действия с планами лечения:");
            Console.WriteLine();

            ConsoleUtility.WriteLineColored(
                "Нажмите любую клавишу для продолжения",
                ConsoleColor.Yellow
            );
            Console.ReadKey(true);
            SelectHealingActions();
        }

        private static void AssignHealingPlan()
        {
            Console.Clear();
            Patient patient = ObjectSelector<Patient>.SelectFromList(_patients, HealingPlanMessage);

            if (patient != null)
            {
                HealingPlan plan = patient.AssignHealingPlan(_doctors);

                if (plan.AssignedDoctor != null)
                    _healingPlans.Add(plan);
            }
        }

        private static void CheckPatientsHealingPlan()
        {
            List<Patient> patientsWithPlan = _patients.Where(p => p.IsHealingPlanAssigned).ToList();

            if (patientsWithPlan.Count > 0)
            {
                Patient patient = ObjectSelector<Patient>.SelectFromList(
                    patientsWithPlan,
                    "Выберите пациента:"
                );

                if (patient != null)
                {
                    Console.Clear();
                    patient.CheckHealingPlan();
                }
            }
            else
            {
                ConsoleUtility.WriteLineColored(
                    "Ни одному из пациентов не назначен план лечения!",
                    ConsoleColor.Red
                );
            }
        }

        private static void PerformHealingPlan()
        {
            Console.Clear();

            if (_healingPlans.Count == 0)
            {
                ConsoleUtility.WriteLineColored(
                    "Отсутствуют планы лечения пациентов",
                    ConsoleColor.Green
                );
            }
            else
            {
                HealingPlan plan = ObjectSelector<HealingPlan>.SelectFromList(
                    _healingPlans,
                    "Выберите план лечения:"
                );

                if (plan != null)
                {
                    bool isHealingSucceed = plan.HealPatient();

                    if (isHealingSucceed)
                    {
                        _healingPlans.Remove(plan);
                        _patients.Remove(plan.AssignedPatient);
                        Console.WriteLine();
                        ConsoleUtility.WriteLineColored(
                            $"Пациент \"{plan.AssignedPatient.Name}\" был выписан из клиники!",
                            ConsoleColor.Green
                        );
                    }
                }
            }
        }
        #endregion
    }
}
