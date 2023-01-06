using System;

namespace _01.SumSeconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int finalTime = first + second + third;

            int minutes = finalTime / 60;
            int seconds = finalTime % 60;

            if(seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            } else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
