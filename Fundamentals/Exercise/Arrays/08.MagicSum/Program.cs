using System;
using System.Linq;

namespace _08.MagicSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < (array.Length / 2) + 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int sumBetweenNums = array[i] + array[j];
                    if (sumBetweenNums == number)
                    {
                        Console.WriteLine($"{array[i]} {array[j]}");
                    }
                }
            }
        }
    }
}
