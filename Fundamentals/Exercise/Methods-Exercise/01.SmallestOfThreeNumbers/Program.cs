using System;

namespace _01.SmallestOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            FindSmallestInteger(num1, num2, num3);
        }

        static void FindSmallestInteger(int num1, int num2, int num3)
        {
            int minNumber = 0;
            if (num1 <= num2 && num1 <= num3)
            {
                minNumber = num1;
            } else if (num2 <= num3)
            {
                minNumber = num2;
            } else
            {
                minNumber = num3;
            }

            Console.WriteLine(minNumber);
        }
    }
}
