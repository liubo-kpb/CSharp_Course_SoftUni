using System;

namespace _03.Time_15Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int afterMins = minutes + 15;

            if(afterMins >= 60)
            {
                hours++;
                afterMins = afterMins - 60;
            }
            if(hours > 23)
            {
                hours -= 24;
            }

            if(afterMins < 10)
            {
                Console.WriteLine($"{hours}:0{afterMins}");
            }
            else
            {
                Console.WriteLine($"{hours}:{afterMins}");
            }
        }
    }
}
