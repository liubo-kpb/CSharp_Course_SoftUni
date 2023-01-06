namespace MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Interfaces;
    internal class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string firstName, string lastName, string id, decimal salary, string corps, Mission[] missions) : base(firstName, lastName, id, salary, corps)
        {
            Missions = missions.ToList<Mission>();
        }

        public List<Mission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"{base.ToString()}");
            str.AppendLine($"Corps: {Corps}");
            str.Append($"Missions:");
            if (Missions.Count > 0)
            {
                str.Append(Environment.NewLine + "  " + string.Join($"{Environment.NewLine}  ", Missions));
            }

            return str.ToString().Trim();
        }
    }
}
