//string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
//Console.WriteLine(string.Join(Environment.NewLine, line.Where(x => char.IsUpper(x[0]))));
string line = Console.ReadLine();
Func<string, bool> findUpperCase = isUpper;

foreach (var word in line.Split(" ", StringSplitOptions.RemoveEmptyEntries))
{
    if (findUpperCase(word))
    {
        Console.WriteLine(word);
    }
}


bool isUpper(string arg)
{

    return char.IsUpper(arg[0]);
}