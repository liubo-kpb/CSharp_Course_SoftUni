using System;
using System.Collections.Generic;

namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] details = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shopName = details[0];
                string product = details[1];
                double price = double.Parse(details[2]);

                if (!shops.ContainsKey(shopName))
                {
                    shops.Add(shopName, new Dictionary<string, double>());
                }
                if (!shops[shopName].ContainsKey(product))
                {
                    shops[shopName].Add(product, price);
                }
                shops[shopName][product] = price;
            }

            foreach (var shop in shops)
            {
                Console.WriteLine(shop.Key + "->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
