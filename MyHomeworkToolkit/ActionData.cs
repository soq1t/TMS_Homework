using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit.ObjectSelecting;

namespace MyHomeworkToolkit
{
    internal class ActionData : ISelectableObject
    {
        public string DisplayedName { get; private set; }
        internal Action PerformedAction { get; private set; }

        internal ActionData(string displayedName, Action performedAction)
        {
            DisplayedName = displayedName;
            PerformedAction = performedAction;
        }
    }
}
