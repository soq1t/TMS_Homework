using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework10_1
{
    internal static class MathInputExtensions
    {
        private static readonly List<char> _operators = new List<char>()
        {
            '+',
            '-',
            '*',
            '/',
            '(',
            ')',
        };

        public static string Clean(this string input)
        {
            input = input.Replace(" ", string.Empty);
            input = input.Replace(',', '.');
            return input;
        }

        public static string RemoveOperators(this string input)
        {
            foreach (char o in _operators)
            {
                if (o == '(' || o == ')')
                {
                    input = input.Replace(o.ToString(), string.Empty);
                }
                else if (o == '-')
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == '-' && i == 0)
                            continue;
                        else if (input[i] == '-' && input[i - 1] == ' ')
                            continue;
                        else if (input[i] == '-')
                            input = input.Substring(0, i) + ' ' + input.Substring(i + 1);
                    }
                }
                else
                {
                    input = input.Replace(o, ' ');
                }
            }

            return input;
        }

        public static List<double> GetDigits(this string input)
        {
            List<double> digits = new List<double>();

            bool lessZeroValue = false;

            foreach (string digit in input.RemoveOperators().Split(' '))
            {
                if (digit == string.Empty)
                {
                    lessZeroValue = true;
                    continue;
                }

                if (lessZeroValue)
                {
                    digits.Add(double.Parse("-" + digit));
                }
                else
                {
                    digits.Add(double.Parse(digit));
                }
            }

            return digits;
        }

        public static List<char> GetOperators(this string input)
        {
            List<char> operators = new List<char>();

            bool foundOperator = false;

            foreach (char c in input)
            {
                if (foundOperator)
                {
                    foundOperator = false;
                    continue;
                }

                if (_operators.Contains(c))
                {
                    operators.Add(c);
                    foundOperator = true;
                }
            }

            return operators;
        }
    }
}
