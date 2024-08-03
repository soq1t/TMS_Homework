using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;
using MyHomeworkToolkit.ObjectSelecting;

namespace Homework8_1
{
    internal abstract class Animal : ISelectableObject
    {
        public string Name { get; private set; }

        public abstract string DisplayedName { get; }

        protected Animal(string name)
        {
            SetName(name);
        }

        public void SetName(string name)
        {
            Name = name;

            ConsoleUtility.WriteColored("Новое имя животного: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteLineColored(name, ConsoleColor.Green);
        }

        public void SetName()
        {
            string name = InputDataHandler.GetTextData("Введите имя животного:");
            SetName(name);
        }

        public void GetName()
        {
            ConsoleUtility.WriteColored("Животное зовут: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteLineColored(Name, ConsoleColor.Green);
        }

        public void Eat(string foodName)
        {
            ConsoleUtility.WriteColored($"[{Name}]", ConsoleColor.Blue);
            ConsoleUtility.WriteColored(" начинает поедание ", ConsoleColor.Cyan);
            ConsoleUtility.WriteLineColored($"[{foodName}]", ConsoleColor.Green);

            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(random.Next(100, 300));

                ConsoleUtility.WriteColored("*-*-*-*-", ConsoleColor.Yellow);
            }

            ConsoleUtility.WriteLineColored("*", ConsoleColor.Yellow);

            ConsoleUtility.WriteColored($"[{Name}]", ConsoleColor.Blue);
            ConsoleUtility.WriteColored($" съел ", ConsoleColor.Cyan);
            ConsoleUtility.WriteColored($"[{foodName}]", ConsoleColor.Green);

            if (random.Next(0, 10) < 3)
                ConsoleUtility.WriteLineColored(" и просит добавки!!!", ConsoleColor.Cyan);
            else
                ConsoleUtility.WriteLineColored(" и очень доволен! :)", ConsoleColor.Cyan);
        }

        public void Eat() => Eat("Сухой корм");
    }
}
