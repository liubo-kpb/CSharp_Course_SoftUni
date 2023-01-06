using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Animal
    {
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        
        public override string ToString() =>    $"{GetType().Name}" +
                                                $"\n{Name} {Age} {Gender}" +
                                                $"\n{ProduceSound()}";
        

        public virtual string ProduceSound() => string.Empty;
    }
}
