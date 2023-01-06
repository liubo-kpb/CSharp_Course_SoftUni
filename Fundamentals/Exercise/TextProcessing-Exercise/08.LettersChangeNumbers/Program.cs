using System;

namespace _08.LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double sum = 0.00;
            for (int i = 0; i < input.Length; i++)
            {
                string currentString = input[i];
                char firstLetter = currentString[0];
                double number = int.Parse(currentString.Substring(1, currentString.Length - 2));
                char secondLetter = currentString[currentString.Length - 1];
                if (char.IsUpper(firstLetter))
                {
                    sum += number / (firstLetter - 64);
                }
                else
                {
                    sum += number * (firstLetter - 96);
                }
                if (char.IsUpper(secondLetter))
                {
                    sum -= secondLetter - 64;
                }
                else
                {
                    sum += secondLetter - 96;
                }
            }
            Console.WriteLine($"{sum:F2}");
        }
    }
}
