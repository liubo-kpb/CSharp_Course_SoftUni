using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            string notApplicable = "n/a";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"{Engine.ToString()}");
            sb.AppendLine($"Weight: {(Weight > 0 ? Weight : notApplicable)}");
            sb.AppendLine($"Color: {(Color != null ? Color : notApplicable)}");
            return sb.ToString().Trim();
        }
    }
}
