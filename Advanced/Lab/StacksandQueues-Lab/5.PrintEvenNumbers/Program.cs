using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = Console.ReadLine()
                                  .Split()
                                  .Select(int.Parse)
                                  .ToArray();
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < ints.Length; i++)
            {
                if (ints[i] % 2 == 0)
                {
                    queue.Enqueue(ints[i]);
                }
            }
            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
