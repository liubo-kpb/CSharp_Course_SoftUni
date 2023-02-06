using DefiningClasses;
using System;

public class StartUp
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        Family family = new Family();
        for (int i = 0; i < lines; i++)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = input[0];
            int age = int.Parse(input[1]);
            Person person = new Person(name, age);
            family.AddMember(person);
        }

        foreach (var person in family.People.OrderBy(p => p.Name))
        {
            if (person.Age > 30)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}