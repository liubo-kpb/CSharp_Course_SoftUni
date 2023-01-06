using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOfProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < lines; i++)
            {
                list.Add(Console.ReadLine());
            }
            
            list.Sort();

            for (int i = 0; i < lines; i++)
            {
                list[i] = $"{i + 1}.{list[i]}";
            }

            Console.WriteLine(string.Join(Environment.NewLine, list));
        }
    }
}
