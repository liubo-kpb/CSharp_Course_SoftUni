namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] details = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    string action = details[0];
                    string teamName = details[1];
                    Team team = teams.FirstOrDefault(x => x.Name == teamName);
                    if (team == null && action != "Team")
                        throw new InvalidOperationException($"Team {teamName} does not exist.");

                    string playerName = string.Empty;
                    if (details.Length > 2)
                        playerName = details[2];

                    switch (action)
                    {
                        case "Team":
                            Team newTeam = new Team(teamName);
                            teams.Add(newTeam);

                            break;
                        case "Add":
                            int endurance = int.Parse(details[3]);
                            int sprint = int.Parse(details[4]);
                            int dribble = int.Parse(details[5]);
                            int passing = int.Parse(details[6]);
                            int shooting = int.Parse(details[7]);

                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                            team.AddPlayer(player);
                            break;
                        case "Remove":
                            team.RemovePlayer(playerName);

                            break;
                        case "Rating":
                            
                            Console.WriteLine($"{team.Name} - {team.Rating()}");
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

            }
        }
    }
}
