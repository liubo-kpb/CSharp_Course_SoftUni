using System;

namespace _04.CenturiesToMinutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            decimal days = Math.Floor(years * 365.2422m);
            decimal hours = days * 24;
            decimal minutes = hours * 60;

            Console.WriteLine($"{centuries} centuries = {years} years = {days:F0} days = {hours:F0} hours = {minutes:F0} minutes");
        }
    }
}
