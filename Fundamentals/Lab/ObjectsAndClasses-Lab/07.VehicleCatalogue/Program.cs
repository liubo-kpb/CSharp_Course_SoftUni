using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split('/');
                string type = cmdArgs[0];
                string brand = cmdArgs[1];
                string model = cmdArgs[2];
                int property = int.Parse(cmdArgs[3]);

                switch (type)
                {
                    case "Car":
                        Car car = new Car(brand, model, property);
                        catalog.Cars.Add(car);
                        break;
                    case "Truck":
                        Truck truck = new Truck(brand, model, property);
                        catalog.Trucks.Add(truck);
                        break;
                }
            }
            catalog.OrderAlphabetically();
            catalog.PrintCatalog();
        }
    }

    public class Catalog
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }

        public void OrderAlphabetically()
        {
            Cars = Cars.OrderBy(x => x.Brand).ToList();
            Trucks = Trucks.OrderBy(x => x.Brand).ToList();
        }

        public void PrintCatalog()
        {
            if (Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in Cars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in Trucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }

    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }
    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }
    }
}
