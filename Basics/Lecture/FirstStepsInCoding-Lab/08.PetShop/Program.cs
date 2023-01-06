using System;

namespace _08.PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dogFood = 2.5;
            double catFood = 4;

            int dogFoods = int.Parse(Console.ReadLine());
            int catFoods = int.Parse(Console.ReadLine());

            double sum = (dogFood * dogFoods) + (catFood * catFoods);

            Console.WriteLine($"{sum} lv.");
        }
    }
}
