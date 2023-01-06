using System;

namespace _09.PadawanEq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightSaber = double.Parse(Console.ReadLine());
            double robe = double.Parse(Console.ReadLine());
            double belt = double.Parse(Console.ReadLine());

            int lightsaberCount = students + (int)Math.Ceiling((students * 0.10));

            double lightsaberCost = lightSaber * lightsaberCount;
            double robeCost = robe * students;
            double beltCost = (students - (students / 6)) * belt;
            
            double totalCost = lightsaberCost + robeCost + beltCost;

            if (money >= totalCost)
            {
                Console.WriteLine($"The money is enough - it would cost {totalCost:F2}lv.");
            } else
            {
                Console.WriteLine($"John will need {totalCost - money:F2}lv more.");
            }
        }
    }
}
