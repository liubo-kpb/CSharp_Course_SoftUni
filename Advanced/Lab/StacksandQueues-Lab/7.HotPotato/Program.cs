using System;
using System.Collections.Generic;

namespace _7.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> kids = new Queue<string>(Console.ReadLine().Split());
            int hotPotato = int.Parse(Console.ReadLine());

            int hotness = 1;
            while (kids.Count > 1)
            {
                string kid = kids.Dequeue();
                if (hotness++ == hotPotato)
                {
                    Console.WriteLine($"Removed {kid}");
                    hotness = 1;
                }
                else
                {
                    kids.Enqueue(kid);
                }
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
