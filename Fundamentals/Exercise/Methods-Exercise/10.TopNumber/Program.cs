using System;

namespace _10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endValue = int.Parse(Console.ReadLine());

            PrintTopNumber(endValue);
        }

        static void PrintTopNumber(int endValue)
        {
            for (int i = 1; i <= endValue; i++)
            {
                if (IsDividableByEight(i) && HoldsOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsDividableByEight(int number)
        {
            bool isDividableByEight = false;

            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            if (sum % 8 == 0)
            {
                isDividableByEight = true;
            }

            return isDividableByEight;
        }

        static bool HoldsOddDigit (int number)
        {
            bool holdsOddDigit = false;

            while (number > 0)
            {
                int currentNumber = number % 10;

                if (currentNumber % 2 == 1)
                {
                    holdsOddDigit = true;
                    break;
                }

                number /= 10;
            }

            return holdsOddDigit;
        }
    }
}
