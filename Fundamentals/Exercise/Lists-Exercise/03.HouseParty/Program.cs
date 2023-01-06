using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandLines = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();
            for (int i = 0; i < commandLines; i++)
            {
                string command = Console.ReadLine();
                string[] cmdArgs = command.Split(' ');
                if (command.Contains("not going"))
                {
                    if (guestList.Contains(cmdArgs[0]))
                    {
                        guestList.Remove(cmdArgs[0]);
                        continue;
                    }
                    Console.WriteLine($"{cmdArgs[0]} is not in the list!");
                }
                else
                {
                    if (guestList.Contains(cmdArgs[0]))
                    {
                        Console.WriteLine($"{cmdArgs[0]} is already in the list!");
                        continue;
                    }
                    guestList.Add(cmdArgs[0]);
                }
            }
            for (int i = 0; i < guestList.Count; i++)
            {
                Console.WriteLine(guestList[i]);
            }
        }
    }
}
