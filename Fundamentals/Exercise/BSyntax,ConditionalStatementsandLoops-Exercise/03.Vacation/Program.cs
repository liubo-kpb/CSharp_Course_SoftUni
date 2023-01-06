using System;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string group = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double cost = 0;
            switch (group)
            {
                case "Students":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            cost = 8.45;
                            break;
                        case "Saturday":
                            cost = 9.8;
                            break;
                        case "Sunday":
                            cost = 10.46;
                            break;
                    }
                    break;
                case "Business":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            cost = 10.9;
                            break;
                        case "Saturday":
                            cost = 15.6;
                            break;
                        case "Sunday":
                            cost = 16;
                            break;
                    }
                    break;
                case "Regular":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            cost = 15;
                            break;
                        case "Saturday":
                            cost = 20;
                            break;
                        case "Sunday":
                            cost = 22.5;
                            break;
                    }
                    break;
            }
            cost *= people;

            switch (group)
            {
                case "Students":
                    if (people >= 30)
                    {
                        cost *= 0.85;
                    }
                    break;
                case "Business":
                    if (people >= 100)
                    {
                        cost -= (cost / people) * 10;
                    }
                    break;
                case "Regular":
                    if (people >= 10 && people <= 20)
                    {
                        cost *= 0.95;
                    }
                    break;
            }

            Console.WriteLine($"Total price: {cost:F2}");
        }
    }
}
