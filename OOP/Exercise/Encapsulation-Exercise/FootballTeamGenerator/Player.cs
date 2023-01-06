namespace FootballTeamGenerator
{
    using System;
    internal class Player
    {
        private const string exceptionStatsMessage = "{0} should be between 0 and 100.";

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("A name should not be empty.");

                name = value;
            }
        }

        private int Endurance
        {
            set
            {
                if (value < 0 || value > 100) throw new ArgumentException(string.Format(exceptionStatsMessage, nameof(Endurance)));

                endurance = value;
            }
        }
        private int Sprint
        {
            set
            {
                if (value < 0 || value > 100) throw new ArgumentException(string.Format(exceptionStatsMessage, nameof(Sprint)));

                sprint = value;
            }
        }
        private int Dribble
        {
            set
            {
                if (value < 0 || value > 100) throw new ArgumentException(string.Format(exceptionStatsMessage, nameof(Dribble)));

                dribble = value;
            }
        }
        private int Passing
        {
            set
            {
                if (value < 0 || value > 100) throw new ArgumentException(string.Format(exceptionStatsMessage, nameof(Passing)));

                passing = value;
            }
        }
        private int Shooting
        {
            set
            {
                if (value < 0 || value > 100) throw new ArgumentException(string.Format(exceptionStatsMessage, nameof(Shooting)));

                shooting = value;
            }
        }
        public double Stat() => (endurance + sprint + dribble + passing + shooting) / 5.0;
    }
}
