using System;

namespace _02.SleepyTomCat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int vacation = int.Parse(Console.ReadLine());

            int norm = 30000;
            int work = 63;
            int absence = 127;
            int year = 365;

            int workDays = year - vacation;
            int playTime = workDays * work + (vacation * absence);
            int difference = Math.Abs(playTime - norm);

            if (playTime > norm)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{difference / 60} hours and {difference % 60} minutes more for play");
            }
            else {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{difference / 60} hours and {difference % 60} minutes less for play");
            }
        }
    }
}
