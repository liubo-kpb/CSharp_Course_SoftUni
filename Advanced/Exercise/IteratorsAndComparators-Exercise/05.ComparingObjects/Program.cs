using _05.ComparingObjects;

List<Person> people = new List<Person>();
string input = string.Empty;
while ((input = Console.ReadLine()) != "END")
{
    string[] details = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string name = details[0];
    int age = int.Parse(details[1]);
    string town = details[2];
    people.Add(new Person(name, age, town));
}

int n = int.Parse(Console.ReadLine());
Person chosenPerson = people[n - 1];
int matches = 0;
int misses = 0;
for (int i = 0; i < people.Count; i++)
{
    if (chosenPerson.CompareTo(people[i]) == 0)
    {
        ++matches;
    }
    else
    {
        ++misses;
    }
}
if (matches == 1)
{
    Console.WriteLine("No matches");
}
else
{
    Console.WriteLine($"{matches} {misses} {people.Count}");
}