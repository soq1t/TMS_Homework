using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    internal class Phone
    {
        private string _number;
        private string _model;
        private double _weight;

        public string Number
        {
            get => (string.IsNullOrEmpty(_number)) ? "Номер телефона не указан!" : "+" + _number;
            set
            {
                value = value.Replace(" ", string.Empty).Trim();
                bool isNumberCorrect = true;

                foreach (char c in value)
                {
                    if (!Int32.TryParse(c.ToString(), out int x))
                    {
                        isNumberCorrect = false;
                        Console.WriteLine("Неверный формат номера (нужно только цифры)");
                        break;
                    }
                }

                if (isNumberCorrect)
                    _number = value;
            }
        }
        public string Model
        {
            get => (string.IsNullOrEmpty(_model)) ? "Модель телефона не указана" : _model;
            set => _model = value;
        }
        public double Weight
        {
            get => _weight;
            set
            {
                if (value < 0)
                    Console.WriteLine("Вес не может быть отрицательным!");
                else if (value == 0)
                    Console.WriteLine("У телефона должен быть какой-то вес!");
                else
                    _weight = value;
            }
        }

        public void ReceiveCall(string name) => Console.WriteLine($"Вам звонит абонент: {name}");

        public void ReceiveCall(string name, string number)
        {
            ReceiveCall(name);
            Console.WriteLine($"Номер телефона звонящего абонента: +{number}");
        }

        public void SendMessage(params string[] numbers)
        {
            Console.WriteLine("Сообщение будет отправлено по следующим номерам:");

            foreach (string number in numbers)
                Console.WriteLine($"+{number}");
        }

        public string GetNumber() => Number;

        public Phone(string number, string model, double weight)
            : this(number, model)
        {
            Weight = weight;
        }

        public Phone(string number, string model)
        {
            Number = number;
            Model = model;
        }

        public Phone()
            : this(null, null, 0) { }
    }
}
