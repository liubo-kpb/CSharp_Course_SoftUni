using System;
using System.Collections.Generic;

namespace _6.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                switch (input)
                {
                    case "Paid":
                        foreach(var element in queue)
                        {
                            Console.WriteLine(element);
                        }
                        queue.Clear();
                        break;
                    default:
                        queue.Enqueue(input);
                        break;
                }
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
