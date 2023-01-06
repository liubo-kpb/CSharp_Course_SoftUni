using System;

namespace _01.NumberPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int nums = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (nums > n)
                    {
                        break;
                    }
                    Console.Write(nums++ + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
