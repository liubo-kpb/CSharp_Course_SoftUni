using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split(' ');
                string action = cmdArgs[0];
                int number = int.Parse(cmdArgs[1]);

                switch (action)
                {
                    case "Add":
                        numbers.Add(number);
                        break;
                    case "Remove":
                        numbers.Remove(number);
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(number);
                        break;
                    case "Insert":
                        int index = int.Parse(cmdArgs[2]);
                        numbers.Insert(index, number);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
