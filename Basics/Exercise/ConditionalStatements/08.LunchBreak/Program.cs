using System;

namespace _08.LunchBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int episodeLength = int.Parse(Console.ReadLine());
            int breakLength = int.Parse(Console.ReadLine());

            // тук деленето на 8 и 4 трябва да е умножение с десетично число, за да може резултатът да бъде double и по-долу да излезе закръглянето на редове 19 и 23
            double lunch = breakLength * 0.125; 
            double unwind = breakLength * 0.25;
            double freeTime = breakLength - lunch - unwind;

            if (freeTime >= episodeLength)
            {
                Console.WriteLine($"You have enough time to watch {name} and left with {Math.Ceiling(freeTime - episodeLength)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {name}, you need {Math.Ceiling(episodeLength - freeTime)} more minutes.");
            }
        }
    }
}
