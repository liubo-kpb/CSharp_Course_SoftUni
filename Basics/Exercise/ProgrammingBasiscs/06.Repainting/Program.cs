using System;

namespace _06.Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double naylon = 1.5;
            double paintPerLiter = 14.5;
            double razdelitel = 5;
            double bags = 0.4;

            int amountNaylon = int.Parse(Console.ReadLine());
            int amountPaint = int.Parse(Console.ReadLine());
            int amountRazdelitel = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double matterialCost = (naylon * (amountNaylon + 2)) + (paintPerLiter * (amountPaint * 1.1)) + (razdelitel * amountRazdelitel) + bags;

            double costWorker = 0.3 * matterialCost * hours;
            double finalPrice = costWorker + matterialCost;

            Console.WriteLine(finalPrice);
        }
    }
}
