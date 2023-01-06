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

            bool isChanged = false;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split(' ');
                string action = cmdArgs[0];
                int number = 0;
                int index = 0;

                switch (action)
                {
                    case "Add":
                        number = int.Parse(cmdArgs[1]);
                        numbers.Add(number);
                        isChanged = true;
                        break;
                    case "Remove":
                        number = int.Parse(cmdArgs[1]);
                        numbers.Remove(number);
                        isChanged = true;
                        break;
                    case "RemoveAt":
                        index = int.Parse(cmdArgs[1]);
                        numbers.RemoveAt(index);
                        isChanged = true;
                        break;
                    case "Insert":
                        number = int.Parse(cmdArgs[1]);
                        index = int.Parse(cmdArgs[2]);
                        numbers.Insert(index, number);
                        isChanged = true;
                        break;
                    case "Contains":
                        number = int.Parse(cmdArgs[1]);
                        if (numbers.Contains(number))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 1)));
                        break;
                    case "GetSum":
                        Console.WriteLine(numbers.Sum(x => x));
                        break;
                    case "Filter":
                        string condition = cmdArgs[1];
                        number = int.Parse(cmdArgs[2]);
                        if (condition == "<")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x < number)));
                        }
                        else if (condition == ">")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x > number)));
                        }
                        else if (condition == ">=")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x >= number)));
                        }
                        else if (condition == "<=")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x <= number)));
                        }
                        break;
                }
            }

            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
