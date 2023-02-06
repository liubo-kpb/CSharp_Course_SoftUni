Action<string[]> print = str => Console.WriteLine(string.Join(Environment.NewLine, str));

string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
print(input);