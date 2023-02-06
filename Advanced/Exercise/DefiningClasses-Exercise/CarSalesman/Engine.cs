using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacements { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            string notApplicable = "n/a";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\t{Model}:");
            sb.AppendLine($"\t\tPower: {Power}");
            sb.AppendLine($"\t\tDisplacement: {(Displacements > 0 ? Displacements : notApplicable)}");
            sb.AppendLine($"\t\tEfficiency: {(Efficiency != null ? Efficiency : notApplicable)}");

            return sb.ToString().Trim();
        }
    }
}