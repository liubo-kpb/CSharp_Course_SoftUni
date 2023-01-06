using System;

namespace _05.SmallShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantinty = double.Parse(Console.ReadLine());

            double price = 0.00;

            if (city == "Sofia")
            {
                switch (product)
                {
                    case "coffee":
                        price = quantinty * 0.5;
                        break;
                    case "water":
                        price = quantinty * 0.8;
                        break;
                    case "beer":
                        price = quantinty * 1.2;
                        break;
                    case "sweets":
                        price = quantinty * 1.45;
                        break;
                    case "peanuts":
                        price = quantinty * 1.6;
                        break;
                }
            }
            else if (city == "Plovdiv")
            {
                switch (product)
                {
                    case "coffee":
                        price = quantinty * 0.4;
                        break;
                    case "water":
                        price = quantinty * 0.7;
                        break;
                    case "beer":
                        price = quantinty * 1.15;
                        break;
                    case "sweets":
                        price = quantinty * 1.3;
                        break;
                    case "peanuts":
                        price = quantinty * 1.5;
                        break;
                }
            }
            else if (city == "Varna")
            {
                switch (product)
                {
                    case "coffee":
                        price = quantinty * 0.45;
                        break;
                    case "water":
                        price = quantinty * 0.7;
                        break;
                    case "beer":
                        price = quantinty * 1.1;
                        break;
                    case "sweets":
                        price = quantinty * 1.35;
                        break;
                    case "peanuts":
                        price = quantinty * 1.55;
                        break;
                }
            }
            Console.WriteLine(price);
        }
    }
}
