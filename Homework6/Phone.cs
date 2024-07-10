using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyHomeworkToolkit.ErrorHandler;

namespace Homework6
{
    internal class Phone
    {
        private long _number;
        private string _model;
        private double _weight;
        public long Number
        {
            set
            {
                if (value.ToString().Length < 12)
                    ShowError("Длина номера должна быть 12 цифр!");
                else
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
            set
            {
                if (value < 0)
                    ShowError("Вес не может быть отрицательным!");
                else if (value == 0)
                    ShowError("У телефона должен быть какой-то вес!");
                else
                    _weight = value;
            }
        }
        public string FormattedWeight => string.Format("{0:N2} г.", _weight);

        public void ReceiveCall(string name) => Console.WriteLine($"Вам звонит абонент: {name}");

        public void ReceiveCall(string name, long number)
        {
            ReceiveCall(name);
            Console.WriteLine(
                $"Номер телефона звонящего абонента: {number.ToString("+### (##) ###-##-##")}"
            );
        }

        public void SendMessage(params long[] numbers)
        {
            Console.WriteLine("Сообщение будет отправлено по следующим номерам:");

            foreach (long number in numbers)
                Console.WriteLine(number.ToString("+### (##) ###-##-##"));
        }

        public string GetNumber() =>
            (_number == 0)
                ? "Номер не указан!"
                : string.Format("{0: +### (##) ###-##-##}", _number);

        public Phone(long number, string model, double weight)
            : this(number, model)
        {
            _weight = weight;
        }

        public Phone(long number, string model)
        {
            _number = number;
            _model = model;
        }

        public Phone()
            : this(000000000000, null, 0) { }

        public override string ToString() => $"{Model} ({GetNumber()})";
    }
}
