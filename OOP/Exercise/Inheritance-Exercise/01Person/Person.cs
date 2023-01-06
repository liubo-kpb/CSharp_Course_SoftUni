using System;
using System.Collections.Generic;
using System.Text;

namespace _01Person
{
    public class Person
    {
        public string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append($"Name: {name}, Age: {age}");

            return str.ToString();
        }
    }
}
