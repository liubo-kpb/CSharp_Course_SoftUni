using System;

namespace _05.AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sum = SumOfIntegers(num1, num2);
            Console.WriteLine(SubstractIntegers(sum, num3));
        }

        static int SumOfIntegers (int a, int b)
        {
            return a + b;
        }

        static int SubstractIntegers(int a, int b)
        {
            return a - b;
        }
    }
}
