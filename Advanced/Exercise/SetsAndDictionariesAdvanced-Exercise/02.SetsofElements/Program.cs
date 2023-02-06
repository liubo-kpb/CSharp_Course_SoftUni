using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsofElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setLengths = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = setLengths[0];
            int m = setLengths[1];

            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                set1.Add(num);
            }
            for (int i = 0; i < m; i++)
            {
                int num = int.Parse(Console.ReadLine());
                set2.Add(num);
            }
            set1.IntersectWith(set2);
            Console.WriteLine(string.Join(" ", set1));
        }
    }
}
