using System;

namespace _03.Combinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int counter = 0;
            for (int num1 = 0; num1 <= number; num1++)
            {
                for (int num2 = 0; num2 <= number; num2++)
                {
                    for (int num3 = 0; num3 <= number; num3++)
                    {
                        int result = num1 + num2 + num3;
                        if (result == number)
                        {
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
