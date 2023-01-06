using System;

namespace _01.SignOfIntegerNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FindIntegerSign(int.Parse(Console.ReadLine()));
        }

        static void FindIntegerSign(int number)
        {
            if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            } else if (number == 0)
            {
                Console.WriteLine($"The number {number} is zero. ");
            } else if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive. ");
            }
        }
    }
}
