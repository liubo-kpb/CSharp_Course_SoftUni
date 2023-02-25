using _05.ComparingObjects;

int n = int.Parse(Console.ReadLine());
SortedSet<Person> sSet = new SortedSet<Person>();
HashSet<Person> hSet = new HashSet<Person>();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string name = input[0];
    int age = int.Parse(input[1]);
    Person person = new Person(name, age);
    sSet.Add(person);
    hSet.Add(person);
}

Console.WriteLine(sSet.Count);
Console.WriteLine(hSet.Count);