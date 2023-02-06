List<string> reservations = new List<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
Dictionary<string, List<string>> filters = new Dictionary<string, List<string>>();

Func<string, List<string>, bool> startsWith = (fullString, filterList) =>
{
    foreach (var filter in filterList)
    {
        if (fullString.StartsWith(filter))
        {
            return true;
        }
    }
    return false;
};
Func<string, List<string>, bool> endsWith = (fullString, filterList) =>
{
    foreach (var filter in filterList)
    {
        if (fullString.EndsWith(filter))
        {
            return true;
        }
    }
    return false;
};
Func<string, List<string>, bool> contains = (fullString, filterList) =>
{
    foreach (var filter in filterList)
    {
        if (fullString.Contains(filter))
        {
            return true;
        }
    }
    return false;
};
Func<string, List<string>, bool> equalsLength = (fullString, filterList) =>
{
    foreach (var filter in filterList)
    {
        int number = int.Parse(filter);
        if (fullString.Length == number)
        {
            return true;
        }
    }
    return false;
};

string input = string.Empty;
while ((input = Console.ReadLine()) != "Print")
{
    string[] details = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
    string action = details[0];
    string filter = details[1];
    string variable3 = details[2];

    switch (action)
    {
        case "Add filter":
            if (!filters.ContainsKey(filter))
            {
                filters[filter] = new List<string>();
            }
            filters[filter].Add(variable3);
            break;
        case "Remove filter":
            if (filters[filter].Count > 0)
            {
                filters[filter].Remove(variable3);
            }
            else
            {
                filters.Remove(filter);
            }
            break;
    }
}

for (int i = 0; i < reservations.Count; i++)
{
    string reservation = reservations[i];
    foreach (var filter in filters)
    {
        if ((filter.Key == "Starts with" && startsWith(reservation, filter.Value))
            || (filter.Key == "Ends with" && endsWith(reservation, filter.Value))
            || (filter.Key == "Contains" && contains(reservation, filter.Value))
            || (filter.Key == "Length" && equalsLength(reservation, filter.Value)))
        {
            reservations.Remove(reservation);
            i--;
        }
    }
}
Console.WriteLine(string.Join(' ', reservations));