using System;
using System.Linq;

namespace _3.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] nums = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                int[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    nums[i, j] = line[j];
                }
            }

            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += nums[i, i];
            }
            Console.WriteLine(sum);
        }
    }
}
