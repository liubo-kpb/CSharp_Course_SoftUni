using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@">>([A-Za-z]+)<<(\d+.\d*)!(\d+)\b");
            string input = string.Empty;

            List<string> purchasedFuniture = new List<string>();
            double totalPrice = 0;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match purchase = pattern.Match(input);
                if (purchase.Success)
                {
                    string furniture = purchase.Groups[1].Value;
                    double price = double.Parse(purchase.Groups[2].Value);
                    int quantity = int.Parse(purchase.Groups[3].Value);

                    purchasedFuniture.Add(furniture);
                    totalPrice += price * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");
            if (purchasedFuniture.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, purchasedFuniture));
            }
            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}
