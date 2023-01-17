using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int intelligenceValue = int.Parse(Console.ReadLine());

            int gunLoad = gunBarrel;
            int cost = intelligenceValue;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                int bullet = bullets.Pop();
                cost -= bulletPrice;
                int currentLock = locks.Peek();

                if (currentLock >= bullet)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                gunLoad--;
                if (gunLoad == 0 && bullets.Count > 0)
                {
                    gunLoad = gunBarrel;
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${cost}");
            }
        }
    }
}
