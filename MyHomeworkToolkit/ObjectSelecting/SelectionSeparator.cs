using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeworkToolkit.ObjectSelecting
{
    public enum SeparatorType
    {
        EmptyLine
    }

    internal class SelectionSeparator : ActionData
    {
        private static readonly Dictionary<SeparatorType, string> _typeMap = new Dictionary<
            SeparatorType,
            string
        >()
        {
            { SeparatorType.EmptyLine, string.Empty },
        };

        internal SelectionSeparator(SeparatorType type = SeparatorType.EmptyLine)
            : base(_typeMap[type], null) { }
    }
}
