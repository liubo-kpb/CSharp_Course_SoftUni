using System;

namespace _08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double factorial1 = FindFactorial(num1);
            double factorial2 = FindFactorial(num2);
            double division = factorial1 / factorial2;

            Console.WriteLine($"{division:F2}");
        }

        static double FindFactorial (int number)
        {
            double factorial = 1;
            for (int i = number; i > 0; i--)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
