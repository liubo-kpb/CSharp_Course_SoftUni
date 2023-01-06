using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Kitten : Cat
    {
        private const string KITTENS_GENDER = "Female";

        public Kitten(string name, int age) : base(name, age, KITTENS_GENDER)
        {
        }

        public override string ProduceSound() => "Meow";
    }
}
