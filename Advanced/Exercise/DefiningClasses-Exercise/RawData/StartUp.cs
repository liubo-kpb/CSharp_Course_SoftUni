using RawData;

int carsToCreate = int.Parse(Console.ReadLine());
List<Car> cars = new List<Car>();

for (int i = 0; i < carsToCreate; i++)
{
    string[] carDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string model = carDetails[0];
    int engineSpeed = int.Parse(carDetails[1]);
    int enginePower = int.Parse(carDetails[2]);
    int cargoWeight = int.Parse(carDetails[3]);
    string cargoType = carDetails[4];
    double tire1Pressure = double.Parse(carDetails[5]);
    int tire1Age = int.Parse(carDetails[6]);
    double tire2Pressure = double.Parse(carDetails[7]);
    int tire2Age = int.Parse(carDetails[8]);
    double tire3Pressure = double.Parse(carDetails[9]);
    int tire3Age = int.Parse(carDetails[10]);
    double tire4Pressure = double.Parse(carDetails[11]);
    int tire4Age = int.Parse(carDetails[12]);
    cars.Add(new Car(model,
        new Engine(engineSpeed, enginePower),
        new Cargo(cargoType, cargoWeight),
        new Tire[] { new Tire(tire1Age, tire1Pressure),
            new Tire(tire2Age, tire2Pressure),
            new Tire(tire3Age, tire3Pressure),
            new Tire(tire4Age, tire4Pressure) }));
}

string command = Console.ReadLine();
foreach (var car in cars.Where(c => c.Cargo.Type == command))
{
    if ((command == "fragile" && car.Tires.Any(t => t.Pressure < 1)) || (command == "flammable" && car.Engine.Power > 250))
    {
        Console.WriteLine(car.Model);
    }
}