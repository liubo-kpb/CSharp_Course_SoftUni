using System;
using System.Linq;

namespace _10.LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladybugs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] fieldSetup = new int[fieldSize];
            for (int i = 0; i < ladybugs.Length; i++)
            {
                for (int j = 0; j < fieldSetup.Length; j++)
                {
                    if (ladybugs[i] == j)
                    {
                        fieldSetup[j] = 1;
                    }
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();
                int ladybug = int.Parse(cmdArgs[0]);
                string direction = cmdArgs[1];
                int lengthOfMove = int.Parse(cmdArgs[2]);

                if (fieldSize <= ladybug || 0 > ladybug || fieldSetup[ladybug] == 0 || lengthOfMove == 0)
                {
                    continue;
                }

                bool landed = false;
                while (!landed)
                {
                    int landingZone = 0;
                    switch (direction)
                    {
                        case "right":
                            landingZone = ladybug + lengthOfMove;
                            while (landingZone >= 0 && landingZone < fieldSize && fieldSetup[landingZone] == 1)
                            {
                                landingZone += lengthOfMove;
                            }
                            break;
                        case "left":
                            landingZone = ladybug - lengthOfMove;
                            while (landingZone >= 0 && landingZone < fieldSize && fieldSetup[landingZone] == 1)
                            {
                                landingZone -= lengthOfMove;
                            }
                            break;
                    }
                    landed = true;
                    if (landingZone >= 0 && landingZone < fieldSize)
                    {
                        fieldSetup[landingZone] = 1;
                    }
                    fieldSetup[ladybug] = 0;
                }
            }
            Console.WriteLine(String.Join(" ", fieldSetup));
        }
    }
}
