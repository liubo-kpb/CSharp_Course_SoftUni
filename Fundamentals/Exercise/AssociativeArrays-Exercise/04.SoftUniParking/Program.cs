using System;
using System.Collections.Generic;

namespace _04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> register = new Dictionary<string, string>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string command = input[0];
                string user = input[1];

                if (command == "register")
                {
                    string licensePlateNumber = input[2];
                    if (register.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {register[user]}");
                    }
                    else
                    {
                        register[user] = licensePlateNumber;
                        Console.WriteLine($"{user} registered {licensePlateNumber} successfully");
                    }
                }
                else if (command == "unregister")
                {
                    if (register.ContainsKey(user))
                    {
                        register.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                }
            }

            foreach (var item in register)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
