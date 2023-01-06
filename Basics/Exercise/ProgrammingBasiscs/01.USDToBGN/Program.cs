using System;

namespace _01.USDToBGN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter value to convert to BGN: ");
            
            double usd = double.Parse(Console.ReadLine());
            double bgn = usd * 1.79549;

            Console.WriteLine(bgn);
        }
    }
}
