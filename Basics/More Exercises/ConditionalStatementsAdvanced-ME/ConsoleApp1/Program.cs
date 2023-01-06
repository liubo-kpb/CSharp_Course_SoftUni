using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int group = int.Parse(Console.ReadLine());

            double travelBudget = 0.00;
            if (group <= 4 && group > 0)
            {
                travelBudget = budget * 0.75;
            } else if (group <= 9)
            {
                travelBudget = budget * 0.60;
            } else if (group <= 24)
            {
                travelBudget = budget * 0.50;
            } else if (group <= 49)
            {
                travelBudget = budget * 0.40;
            } else if (group >= 50)
            {
                travelBudget = budget * 0.25;
            }

            double budgetLeft = budget - travelBudget;
            double ticketsCost = 0;
            switch (category)
            {
                case "VIP":
                    ticketsCost = 499.99 * group;
                    if (budgetLeft - ticketsCost >= 0)
                    {
                        Console.WriteLine($"Yes! You have {budgetLeft - ticketsCost:F2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money! You need {ticketsCost - budgetLeft:F2} leva.");
                    }
                    break;
                case "Normal":
                    ticketsCost = 249.99 * group;
                    if (budgetLeft - ticketsCost >= 0)
                    {
                        Console.WriteLine($"Yes! You have {budgetLeft - ticketsCost:F2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money! You need {ticketsCost - budgetLeft:F2} leva.");
                    }
                    break;
            }
            }
        }
}
