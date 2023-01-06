using System;
using System.Drawing;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }
        public string Model { get; private set; }

        public string Color { get; private set; }
        public int Battery { get; private set; }

        public string Start() => "Engine start";
        public string Stop() => "Breaaak!";

        public override string ToString() => $"{Color} {nameof(Tesla)} {Model} with {Battery} Batteries";
    }
}
