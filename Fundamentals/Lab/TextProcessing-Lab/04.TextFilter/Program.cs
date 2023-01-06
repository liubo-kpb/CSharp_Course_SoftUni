using System;

namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] banList = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();
            for (int i = 0; i < banList.Length; i++)
            {
                string censor = new string('*', banList[i].Length);
                text = text.Replace(banList[i], censor);
            }
            Console.WriteLine(text);
        }
    }
}
