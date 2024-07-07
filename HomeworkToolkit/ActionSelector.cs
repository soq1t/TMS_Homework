namespace HomeworkToolkit
{
    public class ActionSelector
    {
        private Dictionary<KeyValuePair<ConsoleKey, string>, Action<object>> _actions;

        public ActionSelector()
        {
            _actions = new Dictionary<KeyValuePair<ConsoleKey, string>, Action<object>>();
        }

        public Action<object> SelectAction(string? initMessage = null)
        {
            if (_actions.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Нет доступных вариантов действий");
            }

            Console.Clear();
            if (initMessage != null)
                Console.WriteLine(initMessage + "\n");

            Console.WriteLine("Выберите действие:");

            foreach (var item in _actions)
            {
                string keyName = item.Key.Key.ToString();
                string message = item.Key.Value;

                Console.WriteLine($"{keyName} - {message}");
            }

            while (true)
            {
                ConsoleKey pressedKey = Console.ReadKey(true).Key;

                foreach (var item in _actions)
                {
                    if (item.Key.Key == pressedKey)
                        return item.Value;
                }
            }
        }

        public void AddAction(ConsoleKey key, string message, Action<object> action)
        {
            KeyValuePair<ConsoleKey, string> keyInfo = new KeyValuePair<ConsoleKey, string>(
                key,
                message
            );

            _actions.Add(keyInfo, action);
        }
    }
}
