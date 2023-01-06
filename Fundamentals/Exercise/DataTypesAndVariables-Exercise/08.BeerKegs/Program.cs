using System;

namespace _08.BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            
            string model = string.Empty;
            double biggestKegVolume = double.MinValue;
            for (int i = 0; i < groups; i++)
            {
                string currentModel = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double currentKegVolume = Math.PI * Math.Pow(radius, 2) * height;
                if (currentKegVolume > biggestKegVolume)
                {
                    model = currentModel;
                    biggestKegVolume = currentKegVolume;
                }
            }

            Console.WriteLine(model);
        }
    }
}
