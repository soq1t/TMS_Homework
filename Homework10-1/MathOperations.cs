using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;

namespace Homework10_1
{
    internal static class MathOperations
    {
        public static bool CheckInput(string input)
        {
            input = input.Clean();

            int openAmount = input.Count(x => x == '(');
            int closeAmount = input.Count(x => x == ')');

            if (openAmount != closeAmount)
                return false;

            input = input.RemoveOperators();

            foreach (string digit in input.Split(' '))
            {
                if (!double.TryParse(digit, out double d))
                {
                    ConsoleUtility.PrintError("Введено некорректное математическое выражение!");
                    return false;
                }
            }

            return true;
        }

        // ( 1 * ( 5 + 5 ) * 2 ) + ( 5 - 3 )
        public static double GetOperationResult(string input, bool printInternalOperations = false)
        {
            input = input.Clean();

            double result;

            while (GetBracketsIndex(input, out int bracketStart, out int bracketEnd))
            {
                string bracketsPart = input.Substring(bracketStart, bracketEnd + 1 - bracketStart);
                string bracketsExpression = bracketsPart.Substring(1, bracketsPart.Length - 2);

                if (printInternalOperations == true)
                {
                    ConsoleUtility.WriteLineColored(
                        new Colored("Найдено выражение в скобках ", ConsoleColor.Cyan),
                        new Colored(bracketsPart, ConsoleColor.Green),
                        new Colored(". Вычисляю...", ConsoleColor.Cyan)
                    );
                    Console.WriteLine();
                }

                double? bracketsResult = GetOperationResult(
                    bracketsExpression,
                    printInternalOperations
                );

                input = input.Replace(bracketsPart, bracketsResult.ToString());
                if (printInternalOperations == true)
                {
                    ConsoleUtility.WriteLineColored(
                        new Colored("Результат вычислений выражения ", ConsoleColor.Cyan),
                        new Colored(bracketsPart, ConsoleColor.Green),
                        new Colored(": ", ConsoleColor.Cyan),
                        new Colored(bracketsResult, ConsoleColor.Green)
                    );
                    Console.WriteLine();
                }
            }

            List<double> digits = input.GetDigits();
            List<char> operators = input.GetOperators();

            if (printInternalOperations == true)
            {
                ConsoleUtility.WriteLineColored(
                    new Colored("Вычисляю выражение: ", ConsoleColor.Cyan),
                    new Colored(input, ConsoleColor.Green)
                );
            }
            while (operators.Count > 0)
            {
                GetOperation(
                    operators,
                    out int operatorIndex,
                    out int aIndex,
                    out int bIndex,
                    out Func<double, double, double> operation
                );

                if (operation == Division && digits[bIndex] == 0)
                    throw new DivideByZeroException();
                double operationResult = Math.Round(
                    operation.Invoke(digits[aIndex], digits[bIndex]),
                    2
                );

                if (printInternalOperations == true)
                {
                    ConsoleUtility.WriteLineColored(
                        $"{digits[aIndex]} {operators[operatorIndex]} {digits[bIndex]} = {operationResult}",
                        ConsoleColor.Green
                    );
                }

                digits[aIndex] = operationResult;

                digits.RemoveAt(bIndex);
                operators.RemoveAt(operatorIndex);
            }

            result = digits.First();
            return Math.Round(result, 2);
        }

        private static void GetOperation(
            List<char> operators,
            out int operatorIndex,
            out int aIndex,
            out int bIndex,
            out Func<double, double, double> operation
        )
        {
            if (operators.Contains('/'))
            {
                operatorIndex = operators.IndexOf('/');

                aIndex = operatorIndex;
                bIndex = operatorIndex + 1;
                operation = Division;
            }
            else if (operators.Contains('*'))
            {
                operatorIndex = operators.IndexOf('*');

                aIndex = operatorIndex;
                bIndex = operatorIndex + 1;
                operation = Multiplication;
            }
            else if (operators.Contains('+'))
            {
                operatorIndex = operators.IndexOf('+');

                aIndex = operatorIndex;
                bIndex = operatorIndex + 1;
                operation = Sum;
            }
            else if (operators.Contains('-'))
            {
                operatorIndex = operators.IndexOf('-');

                aIndex = operatorIndex;
                bIndex = operatorIndex + 1;
                operation = Substraction;
            }
            else
            {
                operatorIndex = -1;

                aIndex = -1;
                bIndex = -1;
                operation = null;
            }
        }

        private static bool GetBracketsIndex(string input, out int start, out int end)
        {
            start = -1;
            end = -1;
            int skipOpenBrackets = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (c == '(')
                {
                    if (start == -1)
                    {
                        start = i;
                    }
                    else
                    {
                        skipOpenBrackets++;
                    }

                    continue;
                }

                if (c == ')')
                {
                    if (skipOpenBrackets == 0)
                    {
                        end = i;
                        break;
                    }
                    else
                    {
                        skipOpenBrackets--;
                    }
                }
            }

            return start != -1;
        }

        private static double Sum(double a, double b) => a + b;

        private static double Substraction(double a, double b) => a - b;

        private static double Multiplication(double a, double b) => a * b;

        private static double Division(double a, double b) => a / b;
    }
}
