using System;

namespace _06.WorldSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double secsPerMeter = double.Parse(Console.ReadLine());

            double resistance = (int)(distance / 15) * 12.5;
            double time = distance * secsPerMeter + resistance;

            if (time < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {time:F02} seconds.");
            } else
            {
                Console.WriteLine($"No, he failed! He was {time - record:F02} seconds slower.");
            }
            
        }
    }
}
