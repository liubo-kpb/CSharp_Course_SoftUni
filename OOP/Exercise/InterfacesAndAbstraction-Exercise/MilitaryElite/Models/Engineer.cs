namespace MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Interfaces;
    internal class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string firstName, string lastName, string id, decimal salary, string corps, Repair[] repairs) : base(firstName, lastName, id, salary, corps)
        {
            Repairs = repairs.ToList<Repair>();
        }

        public List<Repair> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"{base.ToString()}");
            str.AppendLine($"Corps: {Corps}");
            str.Append($"Repairs:");
            if (Repairs.Count > 0)
            {
                str.Append($"{Environment.NewLine}  {string.Join($"{Environment.NewLine}  ", Repairs)}");
            }

            return str.ToString().Trim();
        }
    }
}
