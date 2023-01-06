using System;

namespace _06.FlowerShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int magnolii = int.Parse(Console.ReadLine());
            int zumbuli = int.Parse(Console.ReadLine());
            int rozi = int.Parse(Console.ReadLine());
            int kaktusi = int.Parse(Console.ReadLine());
            double gift = double.Parse(Console.ReadLine());

            double magnoliiLv = 3.25;
            double zumbuliLv = 4;
            double rosiLv = 3.5;
            double kaktusiLv = 8;

            double revenue = (magnolii * magnoliiLv) + (zumbuli * zumbuliLv) + (rozi * rosiLv) + (kaktusi * kaktusiLv);
            double dds = 0.05 * revenue;
            double trueRevenue = revenue - dds;

            if (trueRevenue >= gift)
            {
                Console.WriteLine($"She is left with {Math.Floor(trueRevenue - gift)} leva.");
            } else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(gift - trueRevenue)} leva.");
            }
        }
    }
}
