namespace MilitaryElite.Models
{
    using System;

    using Interfaces;
    internal class Spy : Soldier, ISpy
    {
        public Spy(string firstName, string lastName, string id, int codeNumber) : base(firstName, lastName, id)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString() => $"{base.ToString()}" +
                                            $"{Environment.NewLine}Code Number: {CodeNumber}";
    }
}