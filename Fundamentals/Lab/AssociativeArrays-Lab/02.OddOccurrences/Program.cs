using System.Collections.Generic;
using System;

namespace _02.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].ToLower();
            }
            
            Dictionary<string, int> count = new Dictionary<string, int>();
            foreach (string str in input)
            {
                if (count.ContainsKey(str))
                {
                    count[str]++;
                }
                else
                {
                    count.Add(str, 1);
                }
            }

            List<string> values = new List<string>();
            foreach (string str in count.Keys)
            {
                if (count[str] % 2 == 1)
                {
                    values.Add(str);
                }
            }
            Console.WriteLine(string.Join(" ", values));
        }
    }
}
