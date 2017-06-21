using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inilib
{
    public class ClassAttribute
    {
        public String name { get; set; }
        public String value { get; set; }

        public ClassAttribute() { }

        public ClassAttribute(String name, String value)
        {
            this.name = name;
            this.value = value;
        }

    }
}
