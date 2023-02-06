using CarSalesman;

int enginesToCreate = int.Parse(Console.ReadLine());
Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
for (int i = 0; i < enginesToCreate; i++)
{
    string[] engineDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string model = engineDetails[0];
    int power = int.Parse(engineDetails[1]);
    Engine engine = new Engine(model, power);
    if (engineDetails.Length > 3)
    {
        int displacement = int.Parse(engineDetails[2]);
        engine.Displacements = displacement;
        string efficiency = engineDetails[3];
        engine.Efficiency = efficiency;
    }
    else if (engineDetails.Length > 2)
    {
        string value = engineDetails[2];
        if (value[0] > 57)
        {
            engine.Efficiency = value;
        }
        else
        {
            engine.Displacements = int.Parse(value);
        }
    }
    engines.Add(model, engine);
}

int carsToCreate = int.Parse(Console.ReadLine());
List<Car> cars = new List<Car>();
for (int i = 0; i < carsToCreate; i++)
{
    string[] carDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string model = carDetails[0];
    string engineModel = carDetails[1];
    Car car = new Car(model, engines[engineModel]);
    if (carDetails.Length > 3)
    {
        int weight = int.Parse(carDetails[2]);
        car.Weight = weight;
        string color = carDetails[3];
        car.Color = color;
    }
    else if (carDetails.Length > 2)
    {
        string value = carDetails[2];
        if (value[0] > 57)
        {
            car.Color = value;
        }
        else
        {
            car.Weight = int.Parse(value);
        }
    }
    cars.Add(car);
}

foreach (var car in cars)
{
    Console.WriteLine(car.ToString());
}