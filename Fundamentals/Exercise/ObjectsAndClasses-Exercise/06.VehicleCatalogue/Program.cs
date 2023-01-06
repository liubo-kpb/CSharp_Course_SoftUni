using System.Collections.Generic;
using System.Linq;
using System;

namespace _06.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] details = command.Split();
                string type = details[0];
                string model = details[1];
                string color = details[2];
                int horsePower = int.Parse(details[3]);

                Vehicle vehicle = new Vehicle(type, model, color, horsePower);
                vehicleList.Add(vehicle);
            }
            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                foreach (Vehicle vehicle in vehicleList)
                {
                    if (vehicle.Model == command)
                    {
                        vehicle.printVehicleDetials();
                        break;
                    }
                }

            }

            double carHP = 0;
            double truckHP = 0;
            int cars = 0;
            int trucks = 0;
            foreach (var vehicle in vehicleList)
            {
                if (vehicle.Type == "car")
                {
                    carHP += vehicle.HorsePower;
                    cars++;
                }
                else if (vehicle.Type == "truck")
                {
                    truckHP += vehicle.HorsePower;
                    trucks++;
                }
            }

            double averageCarHP = 0.00;
            double averageTruckHP = 0.00;
            if (cars > 0)
            {
                averageCarHP = carHP / cars;
            }
            if (trucks > 0)
            {
                averageTruckHP = truckHP / trucks;
            }

            Console.WriteLine($"Cars have average horsepower of: {averageCarHP:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTruckHP:F2}.");
        }
    }

    public class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string TypeToUpperFirstCase()
        {
            return char.ToUpper(Type[0]) + Type.Substring(1);
        }

        public void printVehicleDetials()
        {
            Console.WriteLine($"Type: {TypeToUpperFirstCase()}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Horsepower: {HorsePower}");
        }
    }
}