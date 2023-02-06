using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string usernameInput = Console.ReadLine();
                usernames.Add(usernameInput);
            }
            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
