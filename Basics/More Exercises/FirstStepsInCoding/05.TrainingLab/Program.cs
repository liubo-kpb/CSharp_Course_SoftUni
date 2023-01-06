using System;

namespace _05.TrainingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int w = (int) (double.Parse(Console.ReadLine()) * 100);
            int h = (int) (double.Parse(Console.ReadLine()) * 100);

            int desksW = 70;
            int desksL = 120;

            int spaceW = (h - 100) / desksW;
            int spaceL = w / desksL;

            int desks = spaceW * spaceL - 3;

            Console.WriteLine(desks);
        }
    }
}
