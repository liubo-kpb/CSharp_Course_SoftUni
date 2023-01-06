using System;

namespace _05.Everest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            int counter = 1;
            int climb = 5364;
            while (command != "END")
            {
                if (command == "Yes")
                {
                    counter++;
                }

                if (counter > 5)
                {
                    break;
                }
                int meters = int.Parse(Console.ReadLine());
                climb += meters;

                if (climb >= 8848)
                {
                    Console.WriteLine($"Goal reached for {counter} days!");
                    return;
                }

                command = Console.ReadLine();
            }

            if (climb < 8848)
            {
                Console.WriteLine("Failed!");
                Console.WriteLine($"{climb}");
            }
        }
    }
}
