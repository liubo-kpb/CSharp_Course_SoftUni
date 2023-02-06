int length = int.Parse(Console.ReadLine());
string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
Predicate<string> equalsLength = name => name.Length <= length;

foreach (string name in names)
{
    if (equalsLength(name))
    {
        Console.WriteLine(name);
    }
}