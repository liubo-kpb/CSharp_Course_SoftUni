using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                guests.Add(input);
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (guests.Count > 0)
                {
                    guests.Remove(input);
                }
            }

            Console.WriteLine(guests.Count);
            foreach (var guest in guests.Where(x => char.IsDigit(x[0])))
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in guests.Where(x => !char.IsDigit(x[0])))
            {
                Console.WriteLine(guest);
            }
        }
    }
}
