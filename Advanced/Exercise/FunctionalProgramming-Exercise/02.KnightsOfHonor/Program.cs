Action<string[]> print = strArray =>
{
    foreach(var str in strArray)
    {
        Console.WriteLine("Sir " + str);
    }
};

string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
print(input);