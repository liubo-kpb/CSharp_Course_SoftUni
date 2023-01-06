using System;

namespace _05.AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneySaved = 0.0;

            string command = Console.ReadLine();
            double doubleConverter = 0.00;

            while (command != "NoMoreMoney")
            {
                doubleConverter = double.Parse(command);
                
                if (doubleConverter < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                
                moneySaved += doubleConverter;
                Console.WriteLine($"Increase: {doubleConverter:F2}");

                command = Console.ReadLine();
            }

            Console.WriteLine($"Total: {moneySaved:F2}");
        }
    }
}
