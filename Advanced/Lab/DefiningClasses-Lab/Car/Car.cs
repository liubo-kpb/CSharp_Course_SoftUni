using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }
        public Car(string make, string model, int year) : this() 
        {
            Make = make;
            Model = model;
            Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            Tire = tires;
            Engine = engine;
            
        }

        public Tire[] Tire
        {
            get { return tires; }
            set { tires = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public void Drive(double distance)
        {
            double tankFill = FuelQuantity - (distance * FuelConsumption / 100);
            if (tankFill > 0)
            {
                FuelQuantity = tankFill;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {Make}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Year: {Year}");
            sb.AppendLine($"Fuel: {FuelConsumption:F2}");

            return sb.ToString().Trim();
        }
    }
}
