namespace ExplicitInterfaces
{
    using System;

    using Models.Interfaces;
    using Models;
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] details = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = details[0];
                string country = details[1];
                int age = int.Parse(details[2]);

                Citizen citizen = new Citizen(name, country, age);
                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName() + person.GetName());
            }
        }
    }
}
