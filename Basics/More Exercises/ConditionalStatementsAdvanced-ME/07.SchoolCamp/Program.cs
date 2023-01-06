using System;

namespace _07.SchoolCamp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string group = Console.ReadLine();
            int students = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());

            string sport = "";
            double cost = 0;
            switch (season)
            {
                case "Winter":
                    if (group == "boys")
                    {
                        cost = students * nights * 9.60;
                        sport = "Judo";
                    }
                    else if (group == "girls")
                    {
                        cost = students * nights * 9.60;
                        sport = "Gymnastics";

                    }
                    else if (group == "mixed")
                    {
                        cost = students * nights * 10;
                        sport = "Ski";
                    }
                    break;
                case "Spring":
                    if (group == "boys")
                    {
                        cost = students * nights * 7.20;
                        sport = "Tennis";
                    }
                    else if (group == "girls")
                    {
                        cost = students * nights * 7.20;
                        sport = "Athletics";

                    }
                    else if (group == "mixed")
                    {
                        cost = students * nights * 9.50;
                        sport = "Cycling";
                    }
                    break;
                case "Summer":
                    if (group == "boys")
                    {
                        cost = students * nights * 15;
                        sport = "Football";
                    }
                    else if (group == "girls")
                    {
                        cost = students * nights * 15;
                        sport = "Volleyball";

                    }
                    else if (group == "mixed")
                    {
                        cost = students * nights * 20;
                        sport = "Swimming";
                    }
                    break;
            }

            if (students >= 50)
            {
                cost *= 0.50;
            }
            else if (students >= 20)
            {
                cost *= 0.85;
            }
            else if (students >= 10)
            {
                cost *= 0.95;
            }
            
            Console.WriteLine($"{sport} {cost:F2} lv.");
        }
    }
}
