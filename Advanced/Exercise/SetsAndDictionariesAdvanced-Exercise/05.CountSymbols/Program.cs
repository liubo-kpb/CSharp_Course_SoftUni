using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();
            string str = Console.ReadLine();
            for (int i = 0; i < str.Length; i++)
            {
                if (!chars.ContainsKey(str[i]))
                {
                    chars[str[i]] = 0;
                }
                chars[str[i]]++;
            }

            foreach (var c in chars)
            {
                Console.WriteLine($"{c.Key}: {c.Value} time/s");
            }
        }
    }
}
