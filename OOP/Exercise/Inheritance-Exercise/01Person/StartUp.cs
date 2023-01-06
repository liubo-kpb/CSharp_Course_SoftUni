using System;

namespace _01Person
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            
            if (age >= 0 && age < 16)
            {
                Child child = new Child(name, age);
                Console.WriteLine(child);
            } else if (age >= 0)
            {
                Person person = new Person(name, age);
                Console.WriteLine(person);
            }
        }
    }
}
