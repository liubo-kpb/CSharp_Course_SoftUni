using System;

namespace _03.Flowers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hrizantemi = int.Parse(Console.ReadLine());
            int rozi = int.Parse(Console.ReadLine());
            int laleta = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char holiday = char.Parse(Console.ReadLine());

            double cost = 0.00;
            switch (season)
            {
                case "Spring":
                case "Summer":
                    cost = hrizantemi * 2 + rozi * 4.10 + laleta * 2.50;
                    if (holiday == 'Y')
                    {
                        cost += cost * 0.15;
                        
                    }
                    if (laleta > 7 && season == "Spring")
                    {
                        cost *= 0.95;
                    }
                    break;
                case "Autumn":
                case "Winter":
                    cost = hrizantemi * 3.75 + rozi * 4.50 + laleta * 4.15;
                    if (holiday == 'Y')
                    {
                        cost += cost * 0.15;
                        
                    }
                    if (rozi >= 10 && season == "Winter")
                    {
                        cost *= 0.90;
                    }
                    break;
            }

            if (hrizantemi + rozi + laleta > 20)
            {
                cost *= 0.80;
            }
            cost += 2;

            Console.WriteLine($"{cost:F2}");
        }
    }
}
