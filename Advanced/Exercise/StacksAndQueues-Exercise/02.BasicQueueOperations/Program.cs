﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] details = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = details[0];
            int s = details[1];
            int x = details[2];

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> stack = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                stack.Enqueue(numbers[i]);
            }
            for (int i = 0; i < s; i++)
            {
                if (stack.Count > 0)
                {
                    stack.Dequeue();
                }
            }
            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count > 0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
