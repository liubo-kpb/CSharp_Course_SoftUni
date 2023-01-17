using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothesValue = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());

            int rackSpace = 0;
            int rack = 1;
            while (clothesValue.Count > 0)
            {
                if (rackSpace + clothesValue.Peek() <= rackCapacity)
                {
                    rackSpace += clothesValue.Pop();
                }
                else
                {
                    rack++;
                    rackSpace = clothesValue.Pop();
                }
            }
            Console.WriteLine(rack);
        }
    }
}
