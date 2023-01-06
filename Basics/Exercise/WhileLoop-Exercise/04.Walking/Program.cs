using System;

namespace _04.Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stepsGoal = 10000;

            int stepsOverall = 0;
            string command = Console.ReadLine();

            while (command != "Going home" && stepsOverall < stepsGoal)
            {
                int steps = int.Parse(command);
                stepsOverall += steps;
                command = Console.ReadLine();
            }

            if (command == "Going home")
            {
                int steps = int.Parse(Console.ReadLine());
                stepsOverall += steps;
            }

            if (stepsOverall >= stepsGoal)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepsOverall - stepsGoal} steps over the goal!");
            } else
            {
                Console.WriteLine($"{stepsGoal - stepsOverall} more steps to reach goal.");
            }
        }
    }
}
