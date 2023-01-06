using System;
using System.Linq;

namespace _03.Zig_ZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] array1 = new int[n];
            int[] array2 = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] num = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 0)
                {
                    array1[i] = num[0];
                    array2[i] = num[1];
                } else
                {
                    array1[i] = num[1];
                    array2[i] = num[0];
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(array1[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(array2[i] + " ");
            }
        }
    }
}
