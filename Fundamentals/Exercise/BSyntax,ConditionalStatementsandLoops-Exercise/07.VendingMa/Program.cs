using System;

namespace _07.VendingMa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            double money = 0;
            while (command != "End" && command != "Start")
            {
                
                if (command != "0.1" && command != "0.2" && command != "0.5" && command != "1" && command != "2")
                {
                    Console.WriteLine($"Cannot accept {command}");
                } else
                {
                    money += double.Parse(command);
                }

                command = Console.ReadLine();
            }

            double price = 0;
            command = Console.ReadLine();
            while (command != "End")
            {
                bool isValid = true;
                switch (command)
                {
                    case "Nuts":
                        price = 2.0;
                        break;
                    case "Water":
                        price = 0.7;
                        break;
                    case "Crisps":
                        price = 1.5;
                        break;
                    case "Soda":
                        price = 0.8;
                        break;
                    case "Coke":
                        price = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        isValid = false;
                        break;
                }
                if (money >= price && isValid)
                {
                    money -= price;
                    Console.WriteLine($"Purchased {command.ToLower()}");
                }
                else if (money < price && isValid)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Change: {money:F2}");
        }
    }
}
