using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split('|');
            List<int> numbers = new List<int>();
            
            for (int i = array.Length - 1; i >= 0; i--)
            {
                int[] numbersArray = array[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < numbersArray.Length; j++)
                {
                    numbers.Add(numbersArray[j]);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
