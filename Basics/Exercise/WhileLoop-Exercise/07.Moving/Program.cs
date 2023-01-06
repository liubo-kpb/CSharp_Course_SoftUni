using System;

namespace _07.Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int space = width * height * lenght;
            string command = Console.ReadLine();
            while (command != "Done")
            {
                int boxes = int.Parse(command);
                space -= boxes;

                if (space < 0)
                {
                    break;
                }
                command = Console.ReadLine();
            }

            if (command == "Done")
            {
                Console.WriteLine($"{space} Cubic meters left.");
            } else
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(space)} Cubic meters more.");
            }
        }
    }
}
