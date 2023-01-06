using System;

namespace _03.NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int numFlowers = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double finalPrince = 0.00;
            switch (flower)
            {
                case "Roses":
                    finalPrince = numFlowers * 5;
                    if (numFlowers > 80)
                    {
                        finalPrince *= 0.9;
                    }
                    break;
                case "Dahlias":
                    finalPrince = numFlowers * 3.8;
                    if (numFlowers > 90)
                    {
                        finalPrince *= 0.85;
                    }
                    break;
                case "Tulips":
                    finalPrince = numFlowers * 2.8;
                    if (numFlowers > 80)
                    {
                        finalPrince *= 0.85;
                    }
                    break;
                case "Narcissus":
                    finalPrince = numFlowers * 3;
                    if (numFlowers < 120)
                    {
                        finalPrince += 0.85 * finalPrince;
                    }
                    break;
                case "Gladiolus":
                    finalPrince = numFlowers * 2.5;
                    if (numFlowers < 80)
                    {
                        finalPrince +=  0.2 * finalPrince;
                    }
                    break;
            }

            if (finalPrince <= budget)
            {
                Console.WriteLine($"Hey, you have a great garden with {numFlowers} {flower} and {budget - finalPrince:F2} leva left.");
            } else
            {
                Console.WriteLine($"Not enough money, you need {finalPrince - budget:F2} leva more.");
            }
        }
    }
}
