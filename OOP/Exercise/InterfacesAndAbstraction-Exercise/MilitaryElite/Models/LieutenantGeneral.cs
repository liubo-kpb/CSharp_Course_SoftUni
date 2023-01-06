namespace MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Interfaces;
    internal class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string firstName, string lastName, string id, decimal salary, List<ISoldier> privates) : base(firstName, lastName, id, salary)
        {
            Privates = privates;
        }

        public List<ISoldier> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(base.ToString());
            str.Append("Privates:");
            if (Privates.Count > 0)
            {
                str.Append(Environment.NewLine + "  " + string.Join($"{Environment.NewLine}  ", Privates));
            }

            return str.ToString();
        }
    }
}
