using System;

namespace _02.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            CountVowels(str.ToLower());
        }

        static void CountVowels(string str)
        {
            char[] vowels = { 'a', 'e', 'o', 'u', 'i' };
            int count = 0;
            foreach (char cr in str)
            {
                for (int i = 0; i < vowels.Length; i++)
                {
                    if (cr == vowels[i])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
