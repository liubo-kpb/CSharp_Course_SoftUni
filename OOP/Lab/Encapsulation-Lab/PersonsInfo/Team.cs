using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name) : this()
        {
            this.name = name;
        }
        private Team()
        {
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return firstTeam.AsReadOnly(); }
            private set { }
        }
        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return reserveTeam.AsReadOnly(); }
            private set { }
        }

        public override string ToString() => $"First team has {firstTeam.Count} players." + Environment.NewLine
                                           + $"Reserve team has {reserveTeam.Count} players.";

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            } else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
