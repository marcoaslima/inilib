using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inilib.test.Model
{
    public class Person
    {
        public String name { get; set; }
        public Int32 age { get; set; }

        public Person() { }

        public Person(String name, Int32 age)
        {
            this.name = name;
            this.age = age;
        }
    }
}
