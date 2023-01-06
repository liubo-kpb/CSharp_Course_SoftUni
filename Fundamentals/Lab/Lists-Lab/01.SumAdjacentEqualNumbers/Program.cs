using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAdjacentEqualNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numberList = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            for (int i = 0; i < numberList.Count - 1; i++)
            {
                if (numberList[i] == numberList[i + 1])
                {
                    numberList[i] += numberList[i + 1];
                    numberList.RemoveAt(i + 1);
                    i = -1;
                }
            }

            Console.WriteLine(string.Join(" ", numberList));
        }
    }
}
