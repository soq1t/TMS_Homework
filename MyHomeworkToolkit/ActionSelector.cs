using MyHomeworkToolkit.ObjectSelecting;

namespace MyHomeworkToolkit
{
    public class ActionSelector
    {
        public event Action SelectionAborted;

        private List<ActionData> _actions;
        private bool _stopLoop;

        public ActionSelector()
        {
            _actions = new List<ActionData>();
        }

        public void AddExitProgramAction() =>
            AddAction("Выйти из программы", () => Environment.Exit(0));

        public void AddSeparator(SeparatorType type = SeparatorType.EmptyLine) =>
            _actions.Add(new SelectionSeparator(type));

        #region SelectActionRepeated

        public void AbortSelectActionRepeated() => _stopLoop = true;

        public void SelectActionRepeated(
            Action predicatedAction,
            bool pressKeyAfterActionCompleted = true
        )
        {
            int selectedActionIndex = 0;
            while (true)
            {
                if (_stopLoop)
                {
                    _stopLoop = false;
                    break;
                }
                selectedActionIndex = SelectAction(
                    predicatedAction,
                    pressKeyAfterActionCompleted,
                    selectedActionIndex
                );
            }
        }

        public void SelectActionRepeated(
            string message,
            bool pressKeyAfterActionCompleted = true
        ) => SelectActionRepeated(() => DisplayMessage(message), pressKeyAfterActionCompleted);

        public void SelectActionRepeated(bool pressKeyAfterActionCompleted = true) =>
            SelectActionRepeated("Выберите действие:", pressKeyAfterActionCompleted);
        #endregion

        #region SelectAction
        public int SelectAction(
            Action predicatedAction,
            bool pressKeyAfterActionCompleted = true,
            int selectedIndex = 0
        )
        {
            ActionData? selectedAction = ObjectSelector<ActionData>.SelectFromList(
                _actions,
                predicatedAction,
                selectedIndex
            );

            Console.Clear();
            if (selectedAction != null)
            {
                selectedAction.PerformedAction?.Invoke();
            }
            else
            {
                ConsoleUtility.WriteLineColored("Выбор действия был отменён!", ConsoleColor.Red);
                SelectionAborted?.Invoke();
            }

            if (pressKeyAfterActionCompleted)
                ConsoleUtility.PressToContinue();

            Console.Clear();

            if (selectedAction == null)
                return -1;
            else
                return _actions.IndexOf(selectedAction);
        }

        public int SelectAction(
            string message,
            bool pressKeyAfterActionCompleted = true,
            int selectedIndex = 0
        ) =>
            SelectAction(
                () => DisplayMessage(message),
                pressKeyAfterActionCompleted,
                selectedIndex
            );

        public int SelectAction(bool pressKeyAfterActionCompleted = true, int selectedIndex = 0) =>
            SelectAction("Выберите действие:", pressKeyAfterActionCompleted, selectedIndex);
        #endregion
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
