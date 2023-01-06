using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    internal class Team
    {

        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("A name should not be empty.");

                name = value;
            }
        }
        public int Rating()
        {
            if (players != null && players.Count > 0)
            {
                return (int) Math.Round(this.players.Average(p => p.Stat()), 0);
            }

            return 0;
        }

        public void AddPlayer(Player player)
        {
            if (players == null)
                players = new List<Player>();

            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (players.Any(x => x.Name == playerName))
                players.Remove(players.FirstOrDefault(x => x.Name == playerName));
            else
                throw new InvalidOperationException($"Player {playerName} is not in {Name} team.");
        }
    }
}
