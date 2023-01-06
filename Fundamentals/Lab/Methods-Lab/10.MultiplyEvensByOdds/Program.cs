using System;

namespace _10.MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            int sumOfOdd = GetSumOfOddDigits(number);
            int sumOfEven = GetSumOfEvenDigits(number);

            Console.WriteLine(GetMultipleOfEvenAndOdds(sumOfOdd, sumOfEven));
        }

        static int GetMultipleOfEvenAndOdds(int sumOfOdds, int sumOfEvens)
        {
            return sumOfOdds * sumOfEvens;
        }

        static int GetSumOfEvenDigits (int number)
        {
            int sumOfEvens = 0;
            
            while (number > 0)
            {
                int currentNum = number % 10;
                if (currentNum % 2 == 0)
                {
                    sumOfEvens += number % 10;
                }
                number /= 10;
            }

            return sumOfEvens;
        }

        static int GetSumOfOddDigits (int number)
        {
            int sumOfEvens = 0;

            while (number > 0)
            {
                int currentNum = number % 10;
                if (currentNum % 2 != 0)
                {
                    sumOfEvens += number % 10;
                }
                number /= 10;
            }

            return sumOfEvens;
        }
    }
}
