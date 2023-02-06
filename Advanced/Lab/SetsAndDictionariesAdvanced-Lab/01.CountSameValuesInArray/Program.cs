using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> values = new Dictionary<double, int>();
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!values.ContainsKey(nums[i]))
                {
                    values.Add(nums[i], 0);
                }
                values[nums[i]]++;
            }
            foreach (var num in values)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
