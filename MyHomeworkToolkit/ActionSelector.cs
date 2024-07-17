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

        public void SelectAction(
            Action predicatedAction,
            bool pressKeyAfterActionCompleted = true,
            bool repeatSelection = true
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

            if (repeatSelection)
                SelectAction(predicatedAction, pressKeyAfterActionCompleted, repeatSelection);
        }

        public void SelectAction(
            string message,
            bool pressKeyAfterActionCompleted = true,
            bool repeatSelection = true
        ) =>
            SelectAction(
                () => DisplayMessage(message),
                pressKeyAfterActionCompleted,
                repeatSelection
            );

        public void SelectAction(
            bool pressKeyAfterActionCompleted = true,
            bool repeatSelection = true
        ) => SelectAction("Выберите действие:", pressKeyAfterActionCompleted, repeatSelection);

        public void AddAction(string message, Action performedAction)
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
