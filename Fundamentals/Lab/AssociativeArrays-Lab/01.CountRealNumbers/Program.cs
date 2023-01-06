using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<int, double> count = new Dictionary<int, double>();
            foreach (int number in numbers)
            {
                if (count.ContainsKey(number))
                {
                    count[number]++;
                }
                else
                {
                    count.Add(number, 1);
                }
            }

            int[] keys = count.Keys.OrderBy(x => x).ToArray();
            foreach (var key in keys)
            {
                Console.WriteLine($"{key} -> {count[key]}");
            }
        }
    }
}
