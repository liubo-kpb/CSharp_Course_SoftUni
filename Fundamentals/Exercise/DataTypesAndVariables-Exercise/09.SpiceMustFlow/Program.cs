using System;

namespace _09.SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());

            int days = 0;
            int storedSpice = 0;
            while (yield >= 100)
            {
                days++;
                int minedSpice = yield;
                yield -= 10;
                if (minedSpice >= 26)
                {
                    minedSpice -= 26;
                    if (yield < 100 && minedSpice >= 26)
                    {
                        minedSpice -= 26;
                    }
                }
                storedSpice += minedSpice;
            }
            Console.WriteLine(days);
            Console.WriteLine(storedSpice);
        }
    }
}
