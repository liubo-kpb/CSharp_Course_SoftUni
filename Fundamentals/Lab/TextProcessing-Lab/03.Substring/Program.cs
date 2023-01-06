using System;

namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string keyWord = Console.ReadLine();
            string phrase = Console.ReadLine();

            while (phrase.Contains(keyWord))
            {
                int indexOfWord = phrase.IndexOf(keyWord);
                phrase = phrase.Remove(indexOfWord, keyWord.Length);
            }
            Console.WriteLine(phrase);
        }
    }
}
