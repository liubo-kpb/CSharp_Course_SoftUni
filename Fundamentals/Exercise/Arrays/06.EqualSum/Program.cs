using System;
using System.Linq;

namespace _06.EqualSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bool isEqual = false;
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int sumLeft = 0;
                int sumRight = 0;
                for (int j = i + 1; j < array.Length; j++)
                {
                    sumRight += array[j];
                }
                for (int j = 0; j < i; j++)
                {
                    sumLeft += array[j];
                }

                if (sumLeft == sumRight)
                {
                    isEqual = true;
                    index = i;
                    break;
                }
            }

            if (isEqual)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
