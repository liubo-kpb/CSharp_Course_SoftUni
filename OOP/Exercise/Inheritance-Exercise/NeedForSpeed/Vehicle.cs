using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    internal class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            Fuel = fuel;
            HorsePower = horsePower;
        }

        public double DefaultFuelConsumption = 1.25;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual double FuelConsumption() => DefaultFuelConsumption;

        public virtual void Drive(double km)
        {
            Fuel -= km * FuelConsumption();
            //if (Fuel < 0) Fuel = 0;
        }
    }
}
