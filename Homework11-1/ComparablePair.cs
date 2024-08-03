using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11_1
{
    internal class ComparablePair<T, U> : Pair<T, U>, IComparable<ComparablePair<T, U>>
        where T : IComparable<T>
        where U : IComparable<U>
    {
        public ComparablePair(T valueT, U valueU)
            : base(valueT, valueU) { }

        public int CompareTo(ComparablePair<T, U>? other)
        {
            if (other == null)
                throw new ArgumentNullException();

            int compareResultT = ValueT.CompareTo(other.ValueT);

            if (compareResultT == -1 || compareResultT == 1)
                return compareResultT;
            else
                return ValueU.CompareTo(other.ValueU);
        }
    }
}
