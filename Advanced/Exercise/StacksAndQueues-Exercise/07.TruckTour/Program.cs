using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                pumps.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
            }

            int startIndex = 0;
            while (true)
            {
                bool willReach = true;
                int totalLiters = 0;

                foreach (int[] pump in pumps)
                {
                    int liters = pump[0];
                    int distanceToNextPump = pump[1];
                    totalLiters += liters;

                    if (totalLiters - distanceToNextPump < 0)
                    {
                        startIndex++;

                        int[] currentPump = pumps.Dequeue();
                        pumps.Enqueue(currentPump);
                        willReach = false;
                        break;
                    }

                    totalLiters -= distanceToNextPump;
                }
                if (willReach)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }
        }
    }
}