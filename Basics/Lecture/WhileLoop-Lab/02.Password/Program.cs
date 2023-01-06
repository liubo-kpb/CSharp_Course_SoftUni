using System;

namespace _02.Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            string login = Console.ReadLine();
            while (login != password)
            {
                login = Console.ReadLine();
            }

            Console.WriteLine($"Welcome {username}!");
        }
    }
}
