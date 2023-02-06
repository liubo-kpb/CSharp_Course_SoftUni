namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<Tire[]> tires = new List<Tire[]>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] details = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Tire[] tiresCombo = new Tire[4];
                int tire = 0;
                for (int i = 0; i < details.Length - 1; i++)
                {
                    int year = int.Parse(details[i++]);
                    double pressure = double.Parse(details[i]);
                    tiresCombo[tire++] = new Tire(year, pressure);
                }
                tires.Add(tiresCombo);
            }

            List<Engine> engines = new List<Engine>();
            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] details = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(details[0]);
                double cubicCapacity = double.Parse(details[1]);
                engines.Add(new Engine(horsePower, cubicCapacity));
            }

            List<Car> cars = new List<Car>();
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] details = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = details[0];
                string model = details[1];
                int year = int.Parse(details[2]);
                double fuelQuantity = double.Parse(details[3]);
                double fuelConsumption = double.Parse(details[4]);
                int engineIndex = int.Parse(details[5]);
                int tireIndex = int.Parse(details[6]);
                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tireIndex]));
            }
            foreach (Car car in cars.Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330 && x.Tire.Sum(t => t.Pressure) >= 9 && x.Tire.Sum(t => t.Pressure) <= 10))
            {
                car.Drive(20);
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
