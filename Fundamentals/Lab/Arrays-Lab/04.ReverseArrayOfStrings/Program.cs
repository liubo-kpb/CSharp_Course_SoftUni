using System;
using System.Linq;

namespace _04.ReverseArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split();

            for (int i = 0; i < array.Length / 2; i++)
            {
                string currString = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = currString;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
