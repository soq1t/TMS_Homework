namespace HomeworkToolkit
{
    public static class ActionSelector
    {
        public static Action<object> SelectAction(
            Dictionary<KeyValuePair<ConsoleKey, string>, Action<object>> Actions
        )
        {
            Console.Clear();
            Console.WriteLine("Выберите действие:");

            foreach (var item in Actions)
            {
                string keyName = item.Key.Key.ToString();
                string message = item.Key.Value;

                Console.WriteLine($"{keyName} - {message}");
            }

            while (true)
            {
                ConsoleKey pressedKey = Console.ReadKey(true).Key;

                foreach (var item in Actions)
                {
                    if (item.Key.Key == pressedKey)
                        return item.Value;
                }
            }
        }
    }
}
