List<string> guests = new List<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

Func<string, string, bool> startsWith = (fullString, subString) => fullString.StartsWith(subString);
Func<string, string, bool> endsWith = (fullString, subString) => fullString.EndsWith(subString);

string input = string.Empty;
while ((input = Console.ReadLine()) != "Party!")
{
    string[] details = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string action = details[0];
    string filter = details[1];
    string variable3 = details[2];

    int cycles = guests.Count;
    switch (action)
    {
        case "Double":
            for(int i = 0; i < cycles; i++)
            {
                if ((filter == "StartsWith" && startsWith(guests[i], variable3))
                    || (filter == "EndsWith" && endsWith(guests[i], variable3))
                    || (filter == "Length" && guests[i].Length == int.Parse(variable3)))
                {
                    guests.Add(guests[i]);
                }
            }

            break;
        case "Remove":
            for (int i = 0; i < guests.Count; i++)
            {
                if ((filter == "StartsWith" && startsWith(guests[i], variable3))
                    || (filter == "EndsWith" && endsWith(guests[i], variable3))
                    || (filter == "Length" && guests[i].Length == int.Parse(variable3)))
                {
                    guests.Remove(guests[i--]);
                }
            }
            break;
    }
}
if (guests.Count > 0)
{
    Console.Write(string.Join(", ", guests));
    Console.WriteLine(" are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}