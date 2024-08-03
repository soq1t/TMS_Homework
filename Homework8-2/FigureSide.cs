using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MyHomeworkToolkit;

namespace Homework8_2
{
    internal class FigureSide
    {
        private double _value;
        public double Value
        {
            get => _value;
            set
            {
                if (value <= 0)
                {
                    ConsoleUtility.WriteColored("Сторона фигуры ", ConsoleColor.Red);
                    ConsoleUtility.WriteColored($"[{Name}]", ConsoleColor.Yellow);
                    ConsoleUtility.WriteColored(
                        " не может быть принимать отрицательное значение либо значение меньше 0",
                        ConsoleColor.Red
                    );
                    ConsoleUtility.WriteLineColored(
                        "Стороне будет присовено значение 1",
                        ConsoleColor.Cyan
                    );
                    _value = 1;
                }
                else
                {
                    _value = value;
                }
            }
        }

        public string Name { get; private set; }

        public FigureSide(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}
