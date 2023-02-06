using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<string>> forceSide = new Dictionary<string, SortedSet<string>>();

            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string[] info = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string user = info[1];
                    string side = info[0];
                    if (!forceSide.Values.Any(x => x.Contains(user)))
                    {
                        AddUserToSide(side, user, forceSide);
                    }
                }
                else
                {
                    string[] info = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string user1 = info[0];
                    string side1 = info[1];
                    foreach (var forceUser in forceSide)
                    {
                        if (forceUser.Value.Contains(user1))
                        {
                            forceUser.Value.Remove(user1);
                            break;
                        }
                    }
                    AddUserToSide(side1, user1, forceSide);
                    Console.WriteLine($"{user1} joins the {side1} side!");
                }
                input = Console.ReadLine();
            }

            foreach (var side in forceSide.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                    foreach (var user in side.Value)
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }

        static void AddUserToSide(string side, string user, Dictionary<string, SortedSet<string>> dictionary)
        {
            if (!dictionary.ContainsKey(side))
            {
                dictionary[side] = new SortedSet<string>();
            }
            dictionary[side].Add(user);
        }
    }
}
