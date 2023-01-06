using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    internal class Car : Vehicle
    {
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            DefaultFuelConsumption = 3;
        }
    }
}
