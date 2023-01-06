using System;

namespace _06.MultiplyTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number % 10 < 1 || number / 100 % 10 < 1 || number / 10 % 10 < 1)
            {
                return;
            }

            for (int a1 = 1; a1 <= number % 10; a1++)
            {
                for (int a2 = 1; a2 <= number / 10 % 10; a2++)
                {
                    for (int a3 = 1; a3 <= number / 100 % 10; a3++)
                    {
                        Console.WriteLine($"{a1} * {a2} * {a3} = {a1 * a2 * a3};");
                    }
                }
            }
        }
    }
}
