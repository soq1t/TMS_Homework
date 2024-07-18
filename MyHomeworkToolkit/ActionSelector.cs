using MyHomeworkToolkit.ObjectSelecting;

namespace MyHomeworkToolkit
{
    public class ActionSelector
    {
        private List<ActionData> _actions;

        public ActionSelector()
        {
            _actions = new List<ActionData>();
        }

        public void AddExitProgramAction() =>
            AddAction("Выйти из программы", () => Environment.Exit(0));

        public void AddSeparator() => AddAction(null, null);

        public void SelectActionRepeated(Action predicatedAction, bool pressKeyAfterActionCompleted = true)
        {
            while (true) 
            {
                SelectAction(predicatedAction, pressKeyAfterActionCompleted);
            }
        }
        
        public void SelectActionRepeated(
            string message,
            bool pressKeyAfterActionCompleted = true
        ) =>
            SelectActionRepeated(
                () => DisplayMessage(message),
                pressKeyAfterActionCompleted
            );
            
        public void SelectActionRepeated(
            bool pressKeyAfterActionCompleted = true
        ) => SelectActionRepeated("Выберите действие:", pressKeyAfterActionCompleted);

        public void SelectAction(
            Action predicatedAction,
            bool pressKeyAfterActionCompleted = true
        )
        {
            object selectedAction = ObjectSelector<ActionData>.SelectFromList(
                _actions,
                predicatedAction
            );

            Console.Clear();
            if (selectedAction != null)
            {
                ActionData action = (ActionData)selectedAction;
                action.PerformedAction.Invoke();
            }
            else
            {
                ConsoleUtility.WriteLineColored("Выбор действия был отменён!", ConsoleColor.Red);
            }

            if (pressKeyAfterActionCompleted)
                ConsoleUtility.PressToContinue();

            Console.Clear();
        }

        public void SelectAction(
            string message,
            bool pressKeyAfterActionCompleted = true
        ) =>
            SelectAction(
                () => DisplayMessage(message),
                pressKeyAfterActionCompleted
            );

        public void SelectAction(
            bool pressKeyAfterActionCompleted = true
        ) => SelectAction("Выберите действие:", pressKeyAfterActionCompleted);

        public void AddAction(string? message, Action? performedAction)
        {
            ActionData action = new ActionData(message, performedAction);
            _actions.Add(action);
        }

        private void DisplayMessage(string message)
        {
            ConsoleUtility.WriteColored(message, ConsoleColor.Yellow);
            Console.WriteLine();
        }
    }
}
