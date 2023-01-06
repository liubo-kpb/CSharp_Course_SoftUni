using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> deck1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> deck2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (deck1.Count != 0 && deck2.Count != 0)
            {
                if (deck1[0] > deck2[0])
                {
                    deck1.Add(deck1[0]);
                    deck1.Add(deck2[0]);
                    deck1.RemoveAt(0);
                    deck2.RemoveAt(0);
                }
                else if (deck2[0] > deck1[0])
                {
                    deck2.Add(deck2[0]);
                    deck2.Add(deck1[0]);
                    deck2.RemoveAt(0);
                    deck1.RemoveAt(0);
                }
                else if (deck1[0] == deck2[0])
                {
                    deck2.RemoveAt(0);
                    deck1.RemoveAt(0);
                }
            }

            if (deck1.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {deck1.Sum()}");
            }
            else if (deck2.Count > 0)
            {
                Console.WriteLine($"Second player wins! Sum: {deck2.Sum()}");
            }
        }
    }
}
