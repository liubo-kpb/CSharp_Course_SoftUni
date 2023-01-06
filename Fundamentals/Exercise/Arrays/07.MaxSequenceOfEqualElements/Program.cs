using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] sequence = new int[0];
            for (int i = 0; i < array.Length; i++)
            {
                int combo = 0;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        combo++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (combo > sequence.Length)
                {
                    sequence = new int[combo];
                    sequence[0] = array[i];
                    for (int j = 1; j < sequence.Length; j++)
                    {
                        sequence[j] = sequence[0];
                    }
                }
            }
            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
