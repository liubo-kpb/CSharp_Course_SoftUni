using System;
using System.Linq;

namespace _09.KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dnaLength = int.Parse(Console.ReadLine());

            string command = string.Empty;
            int[] bestSequence = new int[dnaLength];
            int bestLength = 0;
            int bestSum = 0;
            int bestIndex = int.MaxValue;
            int bestSample = 0;
            int sample = 0;
            while ((command = Console.ReadLine()) != "Clone them!")
            {
                sample++;
                int[] sequence = command.Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int sum = 0;
                int sequenceLength = 0;
                int sequenceLongest = 0;
                for (int i = 0; i < sequence.Length; i++)
                {
                    if (sequence[i] == 0)
                    {
                        sequenceLength = 0;
                        continue;
                    }

                    sum++;
                    sequenceLength++;
                    if (sequenceLength > sequenceLongest)
                    {
                        sequenceLongest = sequenceLength;
                    }
                }
                string targetString = new string('1', sequenceLongest);
                int currentIndex = string.Join("", sequence).IndexOf(targetString);

                if (bestLength <= sequenceLongest && currentIndex < bestIndex ||
                    bestLength == sequenceLongest && currentIndex == bestIndex && bestSum < sum)
                {
                    bestLength = sequenceLongest;
                    bestSum = sum;
                    bestIndex = currentIndex;
                    bestSample = sample;
                    bestSequence = sequence;
                }
            }
            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSum}.");
            Console.WriteLine($"{string.Join(" ", bestSequence)}");
        }
    }
}
