using DateModifier;
using System;

public class StartUp
{
    static void Main(string[] args)
    {
        string date1 = Console.ReadLine();
        string date2 = Console.ReadLine();
        Console.WriteLine(DateModifier.DateModifier.GetDifferenceInDates(date1, date2));
    }
}