using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ');
            Stack<int> ints = new Stack<int>();
            foreach (var number in numbers)
            {
                ints.Push(int.Parse(number));
            }

            string command = string.Empty;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] input = command.Split(" ");
                string action = input[0];
                switch (action)
                {
                    case "add":
                        int num1 = int.Parse(input[1]);
                        int num2 = int.Parse(input[2]);
                        ints.Push(num1);
                        ints.Push(num2);
                        break;
                    case "remove":
                        int numsToRemove = int.Parse(input[1]);
                        if (ints.Count >= numsToRemove)
                        {
                            for (int i = 0; i < numsToRemove; i++)
                            {
                                ints.Pop();
                            }
                        }
                        break;
                }
            }
            Console.WriteLine("Sum: " + ints.Sum());
        }
    }
}
