using System;
using System.Linq;

namespace _02.FriendListMaintenance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] friends = Console.ReadLine().Split(", ");

            int blacklistedNamesCount = 0;
            int lostNamesCount = 0;
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Report")
            {
                string[] cmdArgs = command.Split(" ");
                string action = cmdArgs[0];

                string name = string.Empty;
                int index = -1;
                switch (action)
                {
                    case "Blacklist":
                        name = cmdArgs[1];
                        int currentBlacklistCount = blacklistedNamesCount;
                        for (int i = 0; i < friends.Length; i++)
                        {
                            if (name == friends[i])
                            {
                                friends[i] = "Blacklisted";
                                Console.WriteLine($"{name} was blacklisted.");
                                blacklistedNamesCount++;
                            }
                        }
                        if (currentBlacklistCount == blacklistedNamesCount)
                        {
                            Console.WriteLine($"{name} was not found.");
                        }
                        break;
                    case "Error":
                        index = int.Parse(cmdArgs[1]);
                        if (index >= 0 && index < friends.Length && friends[index] != "Blacklisted" && friends[index] != "Lost")
                        {
                            name = friends[index];
                            friends[index] = "Lost";
                            lostNamesCount++;
                            Console.WriteLine($"{name} was lost due to an error.");
                        }
                        break;
                    case "Change":
                        index = int.Parse(cmdArgs[1]);
                        string newName = cmdArgs[2];
                        if (index >= 0 && index < friends.Length)
                        {
                            name = friends[index];
                            friends[index] = newName;
                            Console.WriteLine($"{name} changed his username to {newName}.");
                        }
                        break;
                }
            }
            Console.WriteLine($"Blacklisted names: {blacklistedNamesCount}");
            Console.WriteLine($"Lost names: {lostNamesCount}");
            Console.WriteLine(string.Join(" ", friends));
        }
    }
}
