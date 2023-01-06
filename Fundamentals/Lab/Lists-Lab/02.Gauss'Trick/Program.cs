using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Gauss_Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int n = list.Count;
            for (int i = 0; i < n / 2; i++)
            {
                list[i] += list[n - 1 - i];
                list.RemoveAt(n - 1 - i);
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
