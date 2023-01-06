using System;
using System.Linq;

namespace _01.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            for (int i = 0; i < words.Length; i++)
            {
                Random rnd = new Random();
                string[] currentWord = new string[words.Length];
                int randomNumber = rnd.Next(0, words.Length);
                if (currentWord[randomNumber] == null)
                {
                    currentWord[randomNumber] = words[i];
                    Console.WriteLine(currentWord[randomNumber]);
                } else
                {
                    i--;
                }

            }
        }
    }
}
