using System;

namespace _04.SumOfTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            bool foundCombination = false;
            int counter = 0;
            for (int num1 = start; num1 <= end; num1++)
            {
                for (int num2 = start; num2 <= end; num2++)
                {
                    counter++;
                    int result = num1 + num2;
                    if (result == magicNumber)
                    {
                        foundCombination = true;
                        Console.WriteLine($"Combination N:{counter} ({num1} + {num2} = {magicNumber})");
                        break;
                    }
                }
                if (foundCombination)
                {
                    break;
                }
            }

            if (!foundCombination)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
            }
        }
    }
}
