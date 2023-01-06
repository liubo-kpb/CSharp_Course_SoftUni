﻿using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sumOdd = 0;
            int sumEven = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    sumEven += array[i];
                }
                else
                {
                    sumOdd += array[i];
                }
            }
            Console.WriteLine(sumEven - sumOdd);
        }
    }
}
