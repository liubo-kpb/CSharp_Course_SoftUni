using System;
using System.Linq;

namespace _04.ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());
            for (int i = 0; i < rotations % array.Length; i++)
            {
                int currentNum = array[0];
                array[0] = array[1];
                for (int j = 1; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Length - 1] = currentNum;
            }

            Console.WriteLine(String.Join(" ", array));
        }
    }
}
