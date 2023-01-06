using System;

namespace _06.ConcatenateData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fName = Console.ReadLine();
            string lName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string town = Console.ReadLine();

            Console.WriteLine($"You are {fName} {lName}, a {age}-years old person from {town}.");
        }
    }
}
