using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11_1
{
    internal class Pair<T, U>
    {
        private T _valueT;
        private U _valueU;

        public T ValueT
        {
            get => _valueT;
            private set => _valueT = value;
        }
        public U ValueU
        {
            get => _valueU;
            private set => _valueU = value;
        }

        public Pair(T valueT, U valueU)
        {
            ValueT = valueT;
            ValueU = valueU;
        }
    }
}
