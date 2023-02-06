int lines = int.Parse(Console.ReadLine());

Dictionary<string, int> people = new Dictionary<string, int>();
for (int i = 0; i < lines; i++)
{
    string[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
    string name = data[0];
    int personAge = int.Parse(data[1]);
    people[name] = personAge;
}

string condition = Console.ReadLine();
int age = int.Parse(Console.ReadLine());
string infoToPrint = Console.ReadLine();
Action<string, int, string> print = PrintCommand;
print(condition, age, infoToPrint);

void PrintCommand(string condition, int age, string infoToPrint)
{
    foreach (var person in people)
    {
        switch (infoToPrint)
        {
            case "name":
                if ((condition == "older" && person.Value >= age) || (condition == "younger" && person.Value < age))
                {
                    Console.WriteLine(person.Key);
                }
                break;
            case "age":
                if ((condition == "older" && person.Value >= age) || (condition == "younger" && person.Value < age))
                {
                    Console.WriteLine(person.Value);
                }
                break;
            case "name age":
                if ((condition == "older" && person.Value >= age) || (condition == "younger" && person.Value < age))
                {
                    Console.WriteLine($"{person.Key} - { person.Value}");
                }
                break;
        }
    }
}