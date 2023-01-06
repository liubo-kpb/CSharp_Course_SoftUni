using System;
using System.Numerics;

namespace _11.Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte snowballs = byte.Parse(Console.ReadLine());

            short bestSnowballSnow = 0;
            short bestSnowballTime = 0;
            short bestSnowballQuality = 0;
            BigInteger bestSnowball = BigInteger.MinusOne;
            for (byte i = 0; i < snowballs; i++)
            {
                short snowballSnow = short.Parse(Console.ReadLine());
                short snowballTime = short.Parse(Console.ReadLine());
                short snowballQuality = short.Parse(Console.ReadLine());
                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                if (bestSnowball <= snowballValue)
                {
                    bestSnowball = snowballValue;
                    bestSnowballQuality = snowballQuality;
                    bestSnowballSnow = snowballSnow;
                    bestSnowballTime = snowballTime;
                }
            }
            Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {bestSnowball} ({bestSnowballQuality})");
        }
    }
}
