using System.Collections.Generic;
using System.Linq;
using System;

namespace _05.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cycles = int.Parse(Console.ReadLine());
            List<Team> teamsList = new List<Team>();
            for (int i = 0; i < cycles; i++)
            {
                string[] teamInfo = Console.ReadLine().Split('-');
                string teamCreator = teamInfo[0];
                string teamName = teamInfo[1];
                if (teamsList.Any(x => x.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                if (teamsList.Any(x => x.Creator == teamCreator))
                {
                    Console.WriteLine($"{teamCreator} cannot create another team!");
                    continue;
                }
                Team team = new Team(teamName, teamCreator);
                Console.WriteLine($"Team {team.Name} has been created by {team.Creator}!");
                teamsList.Add(team);
            }

            string membershipRequest = string.Empty;
            while ((membershipRequest = Console.ReadLine()) != "end of assignment")
            {
                string[] requestDetails = membershipRequest.Split("->");
                string member = requestDetails[0];
                string desiredTeam = requestDetails[1];
                if (!teamsList.Any(x => x.Name == desiredTeam))
                {
                    Console.WriteLine($"Team {desiredTeam} does not exist!");
                    continue;
                }

                bool hasMembership = false;
                foreach (Team team in teamsList)
                {
                    if (team.Members.Any(x => x == member) || team.Creator == member)
                    {
                        hasMembership = true;
                        break;
                    }
                }

                if (hasMembership)
                {
                    Console.WriteLine($"Member {member} cannot join team {desiredTeam}!");
                    continue;
                }
                teamsList.Where(x => x.Name == desiredTeam).ToList().First().Members.Add(member);
            }

            teamsList = teamsList.OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name).ToList();
            List<string> teamsToDisband = new List<string>();
            foreach (Team team in teamsList)
            {
                if (team.Members.Count == 0)
                {
                    teamsToDisband.Add(team.Name);
                    continue;
                }
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");
                team.Members = team.Members.OrderBy(x => x).ToList();
                foreach (string member in team.Members)
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            
            Console.WriteLine("Teams to disband:");
            if (teamsToDisband.Count > 0)
            {
                teamsToDisband = teamsToDisband.OrderBy(x => x).ToList();
                Console.WriteLine(string.Join(Environment.NewLine, teamsToDisband));
            }
        }
    }

    public class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        public Team(string name, string creator)
        {
            Name = name;
            Creator = creator;
            Members = new List<string>();
        }
    }
}
