using System;

namespace _10.PokeMon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int powerStarting = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int targetsPoked = 0;
            int powerLeft = powerStarting;
            while (powerLeft >= distance)
            {
                targetsPoked++;
                powerLeft -= distance;
                if (powerLeft * 2 == powerStarting && powerLeft >= exhaustionFactor && exhaustionFactor > 0)
                {
                    powerLeft /= exhaustionFactor;
                }
            }
            Console.WriteLine(powerLeft);
            Console.WriteLine(targetsPoked);
        }
    }
}
