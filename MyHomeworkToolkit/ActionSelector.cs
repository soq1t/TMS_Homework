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

        public void SelectAction(Action predicatedAction)
        {
            object selectedAction = ObjectSelector<ActionData>.SelectFromList(
                _actions,
                predicatedAction
            );

            if (selectedAction != null)
            {
                Action action = (Action)selectedAction;
                action.Invoke();
            }
        }

        public void SelectAction(string message) => SelectAction(() => DisplayMessage(message));

        public void SelectAction() => SelectAction("Выберите действие:");

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
