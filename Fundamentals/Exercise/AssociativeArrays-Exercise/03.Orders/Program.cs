using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<decimal, int>> products = new Dictionary<string, Dictionary<decimal, int>>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] details = input.Split();
                string product = details[0];
                decimal price = decimal.Parse(details[1]);
                int quanitity = int.Parse(details[2]);

                if (!products.ContainsKey(product))
                {
                    products[product] = new Dictionary<decimal, int>();
                    products[product][price] = 0;
                }
                else if (products.ContainsKey(product))
                {
                    int oldQuantity = products[product][products[product].Keys.First()];
                    products[product] = new Dictionary<decimal, int>();
                    products[product][price] = oldQuantity;
                }

                products[product][price] += quanitity;
            }
            foreach (var product in products)
            {
                foreach (var detail in product.Value)
                {
                    Console.WriteLine($"{product.Key} -> {detail.Key * detail.Value}");
                }
            }
        }
    }
}
