namespace ExplicitInterfaces.Models
{
    using System;

    using Models.Interfaces;
    internal class Citizen : IPerson, IResident
    {

        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; set; }

        public string Country { get; set; }

        public int Age { get; set; }

        string IPerson.GetName() => Name;

        string IResident.GetName() => "Mr/Ms/Mrs ";
    }
}
