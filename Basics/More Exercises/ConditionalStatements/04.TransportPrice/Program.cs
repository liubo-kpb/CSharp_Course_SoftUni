using System;

namespace _04.TransportPrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            double taxiStart = .7;
            double taxiDay = .79;
            double taxiNight = .9;

            double bus = .09;
            double train = .06;

            double costCheapest = 0;

            if (n < 20)
            {
                if (time == "day")
                {
                    costCheapest = taxiStart + taxiDay * n;
                } else if(time == "night")
                {
                    costCheapest = taxiStart + taxiNight * n;
                }
                
            } else if (n < 100)
            {
                costCheapest = bus * n;
            } else if (n >= 100)
            {
                costCheapest = train * n;
            }

            Console.WriteLine($"{costCheapest:F2}");
        }
    }
}
