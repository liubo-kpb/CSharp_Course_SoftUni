using System;

namespace _07.ProjectsCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projects = int.Parse(Console.ReadLine());
            int projectH = 3;

            Console.WriteLine($"The architect {name} will need {projectH*projects} hours to complete {projects} project/s.");
        }
    }
}
