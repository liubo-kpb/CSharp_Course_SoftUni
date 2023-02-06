int number = int.Parse(Console.ReadLine());
string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

Func<string, int, bool> equalsCharacterSum = (name, number) =>
{
    int sum = 0;
	for (int i = 0; i < name.Length; i++)
	{
		sum += name[i];
	}
	if (sum >= number)
	{
		return true;
	}
	return false;
};

Func<string[], int, Func<string, int, bool>, string> engine = (names, number, equalsCharacterSum) =>
{
	for (int i = 0; i < names.Length; i++)
	{
		if (equalsCharacterSum(names[i], number))
		{
			return names[i];
		}
	}
	return string.Empty;
};


Console.WriteLine(engine(names, number, equalsCharacterSum));
