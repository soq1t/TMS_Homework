using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeworkToolkit.ObjectSelecting
{
    public class TextOption : ISelectableObject
    {
        public string DisplayedName { get; }

        public TextOption(string option)
        {
            DisplayedName = option;
        }
    }
}
