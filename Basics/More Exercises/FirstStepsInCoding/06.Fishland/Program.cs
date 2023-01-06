using System;

namespace _06.Fishland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double skumria = double.Parse(Console.ReadLine());
            double zaza = double.Parse(Console.ReadLine());
            double palamudKg = double.Parse(Console.ReadLine());
            double safridKg = double.Parse(Console.ReadLine());
            int midiKg = int.Parse(Console.ReadLine());

            double palamud = skumria * 1.6;
            double safrid = zaza * 1.8;
            double midi = 7.5;

            double cost = (palamud * palamudKg) + (safrid * safridKg) + (midi * midiKg);
            Console.WriteLine($"{cost:F2}");
        }
    }
}
