using System;

namespace _10.MultiplyBy2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (num >= 0)
                {
                    Console.WriteLine($"Result: {num * 2:F2}");
                }
                else
                {
                    Console.WriteLine("Negative number!");
                    break;
                }
            }
        }
    }
}
