using System;

namespace _07.WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte pouringTimes = byte.Parse(Console.ReadLine());

            byte tankFill = 0;
            for (sbyte i = 0; i < pouringTimes; i++)
            {

                short litersPoured = short.Parse(Console.ReadLine());
                byte tankVolume = 255;
                if (litersPoured + tankFill > tankVolume)
                {
                    Console.WriteLine("Insufficient capacity!");
                } else
                {
                    tankFill += (byte) litersPoured;
                }

            }
            Console.WriteLine(tankFill);
        }
    }
}
