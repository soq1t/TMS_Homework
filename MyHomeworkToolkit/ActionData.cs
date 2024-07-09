using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeworkToolkit
{
    internal class ActionData
    {
        internal int Id { get; private set; }
        internal string Message { get; private set; }
        internal Action<object> PerformedAction { get; private set; }
        internal bool IsSeparated { get; private set; }

        internal ActionData(
            int id,
            string message,
            Action<object> performedAction,
            bool isSeparated
        )
        {
            Id = id;
            Message = message;
            PerformedAction = performedAction;
            IsSeparated = isSeparated;
        }
    }
}
