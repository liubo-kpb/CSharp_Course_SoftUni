using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountCharsinaString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> occurances = new Dictionary<char, int>();
            foreach (char ch in input.Where(x => x != ' '))
            {
                if (!occurances.ContainsKey(ch))
                {
                    occurances[ch] = 0;
                }
                occurances[ch]++;
            }
            foreach (var ch in occurances)
            {
                Console.WriteLine($"{ch.Key} -> {ch.Value}");
            }
        }
    }
}
