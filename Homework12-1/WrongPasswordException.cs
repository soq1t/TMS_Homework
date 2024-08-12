using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12_1
{
    internal class WrongPasswordException : Exception
    {
        public WrongPasswordException()
            : base() { }

        public WrongPasswordException(string message)
            : base(message) { }
    }
}
