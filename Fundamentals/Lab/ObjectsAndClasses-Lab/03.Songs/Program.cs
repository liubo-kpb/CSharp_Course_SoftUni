using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> list = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('_');
                string typeList = input[0];
                string name = input[1];
                string time = input[2];

                Song song = new Song(typeList, name, time);
                list.Add(song);
            }

            string input2 = Console.ReadLine();
            if (input2 == "all")
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Name);
                }
            } else
            {
                foreach(var item in list.Where(x => x.Type == input2))
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }

    public class Song
    {
        public string Type;
        public string Name { get; set; }
        public string Time;

        public Song(string type, string name, string time)
        {
            Type = type;
            Name = name;
            Time = time;
        }
    }
}
