using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string vloggerName = cmdArgs[0];
                string action = cmdArgs[1];

                switch (action)
                {
                    case "joined":
                        if (!vloggers.ContainsKey(vloggerName))
                        {
                            vloggers.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                            vloggers[vloggerName].Add("followers", new SortedSet<string>());
                            vloggers[vloggerName].Add("following", new SortedSet<string>());
                        }
                        break;
                    case "followed":
                        string followedVlogger = cmdArgs[2];
                        if (vloggers.ContainsKey(vloggerName) && vloggers.ContainsKey(followedVlogger) && vloggerName != followedVlogger && !vloggers[followedVlogger]["followers"].Contains(vloggerName))
                        {
                            vloggers[followedVlogger]["followers"].Add(vloggerName);
                            vloggers[vloggerName]["following"].Add(followedVlogger);
                        }
                        break;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int vloggerNum = 1;
            foreach (var vlogger in vloggers.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
            {
                Console.WriteLine($"{vloggerNum++}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                if (vloggerNum == 2)
                {
                    foreach (var follower in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }
}
