using System;

namespace _08.BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yearlyPrice = int.Parse(Console.ReadLine());

            double kecove = yearlyPrice - (yearlyPrice * 0.4);
            double ekip = kecove - (kecove * 0.2);
            double ball = ekip * 1 / 4;
            double accesory = ball * 1 / 5;

            double cost = yearlyPrice + kecove + ekip + ball + accesory;

            Console.WriteLine(cost);
        }
    }
}
