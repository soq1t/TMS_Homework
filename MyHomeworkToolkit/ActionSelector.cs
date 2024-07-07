namespace MyHomeworkToolkit
{
    public class ActionSelector
    {
        private List<ActionData> _actions;

        public ActionSelector()
        {
            _actions = new List<ActionData>();
        }

        public Action<object> SelectAction(string? initMessage = null)
        {
            Console.Clear();

            if (_actions.Count == 0)
            {
                Console.WriteLine("Нет доступных вариантов действий!");
                return null;
            }

            int selectedActionIndex = 0;

            while (true)
            {
                Console.Clear();

                if (initMessage != null)
                    Console.WriteLine(initMessage + "\n");

                Console.WriteLine(
                    "Выберите действие (стрелки вверх-вниз - изменить выбор, enter - подтвердить выбор):"
                );
                WriteSeparator();

                foreach (var action in _actions)
                {
                    if (action.IsSeparated)
                    {
                        Console.WriteLine();
                        WriteSeparator();
                    }

                    if (action.Id == selectedActionIndex)
                        Console.Write("> ");

                    Console.WriteLine(action.Message);
                }
                WriteSeparator();

                ConsoleKey pressedKey = Console.ReadKey(true).Key;

                switch (pressedKey)
                {
                    case ConsoleKey.Enter:
                        foreach (ActionData action in _actions)
                        {
                            if (action.Id == selectedActionIndex)
                                return action.PerformedAction;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedActionIndex < _actions.Count - 1)
                            selectedActionIndex++;
                        break;

                    case ConsoleKey.UpArrow:
                        if (selectedActionIndex > 0)
                            selectedActionIndex--;
                        break;
                }
            }
        }

        public void AddAction(
            string message,
            Action<object> performedAction,
            bool isSeparated = false
        )
        {
            int actionId = _actions.Count;
            ActionData action = new ActionData(actionId, message, performedAction, isSeparated);
            _actions.Add(action);
        }

        private void WriteSeparator(int length = 10)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(">=<-");
            }

            Console.WriteLine(">=<");
        }
    }
}
