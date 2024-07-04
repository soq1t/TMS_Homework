using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public enum OperationMode
    {
        FirstX,
        FirstY
    }

    public class MathOperations
    {
        #region Переменные
        private double _x;
        public double X
        {
            get => _x;
            private set => _x = value;
        }

        private double _y;
        public double Y
        {
            get => _y;
            private set => _y = value;
        }
        #endregion
        public MathOperations(double x, double y)
        {
            X = x;
            Y = y;
        }

        #region Арифметические действия с переменными
        /// <summary>
        /// Возвращает сумму <c>X</c> и <c>Y</c>
        /// </summary>
        public double Sum() => X + Y;

        /// <summary>
        /// <example>
        /// <code>
        /// Substraction(OperationMode.FirstX);
        /// </code>
        /// Возвращает X - Y
        /// </example>
        /// <example>
        /// <code>
        /// Substraction(OperationMode.FirstY);
        /// </code>
        /// Возвращает Y - X
        /// </example>
        /// </summary>
        ///
        public double Substraction(OperationMode mode) =>
            (mode == OperationMode.FirstX) ? X - Y : Y - X;

        /// <summary>
        /// Возвращает результат умножения X на Y
        /// </summary>
        /// <returns></returns>
        public double Multiplication() => X * Y;

        /// <summary>
        /// <example>
        /// <code>
        /// Division(OperationMode.FirstX);
        /// </code>
        /// Возвращает X / Y
        /// </example>
        /// <example>
        /// <code>
        /// Division(OperationMode.FirstY);
        /// </code>
        /// Возвращает Y / X
        /// </example>
        /// </summary>
        /// <param name="mode">Опредлеляет, какое число будет делиться на какое</param>
        /// <returns></returns>
        /// <exception cref="DivideByZeroException">ЧИсло, на которое производится деление, равно 0</exception>
        public double Division(OperationMode mode)
        {
            if (mode == OperationMode.FirstX)
                if (Y == 0)
                    throw new DivideByZeroException("Невозможно поделить на 0 (Y = 0)");
                else
                    return X / Y;
            else if (X == 0)
                throw new DivideByZeroException("Невозможно поделить на 0 (X = 0)");
            else
                return Y / X;
        }

        /// <summary>
        /// <example>
        /// <code>
        /// Percent(OperationMode.FirstX);
        /// </code>
        /// Возвращает то, какой процент Y составляет от X
        /// </example>
        /// <example>
        /// <code>
        /// Percent(OperationMode.FirstY);
        /// </code>
        /// Возвращает то, какой процент X составляет от Y
        /// </example>
        /// </summary>
        /// <param name="mode">Определяет, от какого числа отсчитывается процент второго числа</param>
        /// <returns></returns>
        public double Percent(OperationMode mode)
        {
            if (mode == OperationMode.FirstX)
                if (X == 0)
                    throw new DivideByZeroException("Невозможно поделить на 0 (X = 0)");
                else
                    return Y * 100 / X;
            else
            {
                if (Y == 0)
                    throw new DivideByZeroException("Невозможно поделить на 0 (Y = 0)");
                else
                    return X * 100 / Y;
            }
        }

        /// <summary>
        /// <example>
        /// <code>
        /// SquareRoot(OperationMode.FirstX);
        /// </code>
        /// Возвращает квадратный корень числа X
        /// </example>
        /// <example>
        /// <code>
        /// SquareRoot(OperationMode.FirstY);
        /// </code>
        /// Возвращает квадратный корень числа Y
        /// </example>
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public double SquareRoot(OperationMode mode) =>
            (mode == OperationMode.FirstX) ? Math.Sqrt(X) : Math.Sqrt(Y);
        #endregion
    }
}
