using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<Box> orderList = new List<Box>();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();
                
                string serialNumber = cmdArgs[0];
                string itemName = cmdArgs[1];
                int itemQuantity = int.Parse(cmdArgs[2]);
                double itemPrice = double.Parse(cmdArgs[3]);

                Item item = new Item(itemName, itemPrice);
                Box box = new Box(serialNumber, item, itemQuantity, itemQuantity * itemPrice);
                orderList.Add(box);
            }
            orderList = orderList.OrderByDescending(x => x.Price).ToList();
            foreach (var item in orderList)
            {
                Console.WriteLine($"{item.SerialNumber}{Environment.NewLine}" +
                    $"-- {item.Item.Name} - ${item.Item.Price:F2}: {item.ItemQuantity}{Environment.NewLine}" +
                    $"-- ${item.Price:F2}");
            }
        }

    }
    public class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double Price { get; set; }

        public Box(string serialNumber, Item item, int itemQuantity, double priceOfBox)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuantity;
            Price = priceOfBox;
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
