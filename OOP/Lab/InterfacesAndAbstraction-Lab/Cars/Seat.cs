﻿namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }
        public string Model { get; private set; }
        public string Color { get; private set; }

        public string Start() => "Engine start";
        public string Stop() => "Breaaak!";

        public override string ToString() => $"{Color} {nameof(Seat)} {Model}";
    }
}
