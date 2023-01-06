using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string action = cmdArgs[0];
                int number = 0;
                int index = 0;

                switch (action)
                {
                    case "Add":
                        number = int.Parse(cmdArgs[1]);
                        numbers.Add(number);
                        break;
                    case "Insert":
                        number = int.Parse(cmdArgs[1]);
                        index = int.Parse(cmdArgs[2]);
                        if (index >= numbers.Count || index < 0)
                        {
                            Console.WriteLine("Invalid index");
                            continue;
                        }
                        numbers.Insert(index, number);
                        break;
                    case "Remove":
                        index = int.Parse(cmdArgs[1]);
                        if (index >= numbers.Count || index < 0)
                        {
                            Console.WriteLine("Invalid index");
                            continue;
                        }
                        numbers.RemoveAt(index);
                        break;
                    case "Shift":
                        string direction = cmdArgs[1];
                        int times = int.Parse(cmdArgs[2]);
                        if (direction == "left")
                        {
                            for (int i = 0; i < times; i++)
                            {
                                numbers.Add(numbers[0]);
                                numbers.RemoveAt(0);
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = 0; i < times; i++)
                            {
                                numbers.Insert(0, numbers[numbers.Count - 1]);
                                numbers.RemoveAt(numbers.Count - 1);
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
