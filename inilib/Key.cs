using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace inilib
{
    public class Key
    {
        public String Name { get; set; }
        public String Value { get; set; }

        public Key(String Name, String Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        public Int32 ToInteger()
        {
            return Int32.Parse(this.Value);
        }

        public Boolean ToBoolean()
        {
            Boolean result;
            return Boolean.TryParse(this.Value, out result);
        }

        public static bool IsKey(string line)
        {
            var regex = new Regex(@"[a-z]*=[\w]");
            return regex.IsMatch(line);
        }

        public static Key Parse(string line)
        {
            String[] attr = line.Split('=');
            return new Key(attr[0], attr[1]);
        }
    }
}
