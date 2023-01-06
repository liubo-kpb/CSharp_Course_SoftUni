using System;

namespace _01.DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int index = int.Parse(Console.ReadLine());
            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            if (index <= 0 || index > 7)
            {
                Console.WriteLine("Invalid day!");
            } else
            {
                Console.WriteLine(daysOfWeek[index-1]);
            }
        }
    }
}
