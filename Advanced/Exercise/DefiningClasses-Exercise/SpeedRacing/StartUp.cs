using SpeedRacing;

int inputLines = int.Parse(Console.ReadLine());
Dictionary<string, Car> cars = new Dictionary<string, Car>();

for (int i = 0; i < inputLines; i++)
{
    string[] inputDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string model = inputDetails[0];
    double fuelAmount = double.Parse(inputDetails[1]);
    double fuelConsumptionFor1km = double.Parse(inputDetails[2]);

    cars.Add(model, new Car(model, fuelAmount, fuelConsumptionFor1km));
}

string input = string.Empty;
while((input = Console.ReadLine()) != "End")
{
    string[] inputDetails = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string model = inputDetails[1];
    double distance = double.Parse((inputDetails[2]));
    cars[model].Drive(distance);
}

foreach (var car in cars)
{
    Console.WriteLine(car.Value.ToString());
}