using System;

namespace _12.TradeCommissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double volume = double.Parse(Console.ReadLine());

            if (volume < 0)
            {
                Console.WriteLine("error");
                System.Environment.Exit(0);
            }

            double comission = 0.00;
            switch (city)
            {
                case "Sofia":
                    if (volume <= 500)
                    {
                        comission = volume * .05;
                    } else if (volume <= 1000)
                    {
                        comission = volume * .07;
                    } else if (volume <= 10000)
                    {
                        comission = volume * .08;
                    } else if (volume >= 10000)
                    {
                        comission = volume * .12;
                    }
                    break;
                case "Varna":
                    if (volume <= 500)
                    {
                        comission = volume * .045;
                    }
                    else if (volume <= 1000)
                    {
                        comission = volume * .075;
                    }
                    else if (volume <= 10000)
                    {
                        comission = volume * .1;
                    }
                    else if (volume >= 10000)
                    {
                        comission = volume * .13;
                    }
                    break;
                case "Plovdiv":
                    if (volume <= 500)
                    {
                        comission = volume * .055;
                    }
                    else if (volume <= 1000)
                    {
                        comission = volume * .08;
                    }
                    else if (volume <= 10000)
                    {
                        comission = volume * .12;
                    }
                    else if (volume >= 10000)
                    {
                        comission = volume * .145;
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    System.Environment.Exit(0);
                    break;
            }
            Console.WriteLine($"{comission:F2}");
        }
    }
}
