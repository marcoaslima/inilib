using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace inilib
{
    public class Section
    {
        public String Name { get; set; }
        public List<Key> Keys { get; set; }

        public Section()
        {
            this.Keys = new List<Key>();
        }

        public Section(String Name)
        {
            this.Keys = new List<Key>();
            this.Name = Name;
        }

        public static Section None
        {
            get
            {
                return NoneSection();
            }
        }

        private static Section NoneSection()
        {
            Section temp = new Section();
            temp.Name = "untitled";
            return temp;
        }

        public static bool IsSection(String line)
        {
            var regex = new Regex(@"\[[a-z]*\]");
            return regex.IsMatch(line);
        }

        public Key SearchKeys(String Name)
        {
            return this.Keys.SingleOrDefault(item => item.Name == Name);
        }

        public static Section Parse(String line)
        {
            String name = line.Replace('[', ' ').TrimStart();
            name = name.Replace(']', ' ').TrimEnd();
            return new Section(name);
        }
    }
}
