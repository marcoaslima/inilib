using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inilib
{
    public class IniException : Exception
    {
        public IniException()
        {
        }

        public IniException(string message)
            : base(message)
        {
        }
    }
}
