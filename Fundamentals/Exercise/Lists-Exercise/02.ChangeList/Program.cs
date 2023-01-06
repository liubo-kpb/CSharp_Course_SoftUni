using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();
                string action = cmdArgs[0];
                int element = int.Parse(cmdArgs[1]);

                switch (action)
                {
                    case "Delete":
                        numbers.RemoveAll(x => x == element);
                        break;
                    case "Insert":
                        int index = int.Parse(cmdArgs[2]);
                        numbers.Insert(index, element);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
