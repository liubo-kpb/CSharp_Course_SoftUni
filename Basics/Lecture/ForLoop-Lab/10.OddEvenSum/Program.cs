﻿using System;

namespace _10.OddEvenSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int odd = 0;
            int even = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    even += num;
                } else
                {
                    odd += num;
                }
            }
            if (even == odd)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {odd}");
            } else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(even - odd)}");
            }
        }
    }
}
