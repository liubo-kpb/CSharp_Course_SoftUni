using System;

namespace _09.LeftAndRightSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int left = 0;
            int right = 0;
            for (int i = 0; i < n * 2; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i < n)
                {
                    left += num;
                } else
                {
                    right += num;
                }
            }

            if (left == right)
            {
                Console.WriteLine($"Yes, sum = {left}");
            } else
            {
                Console.WriteLine($"No, diff = {Math.Abs(left - right)}");
            }
        }
    }
}
