namespace MilitaryElite.Models
{
    using Interfaces;
    using System;

    internal class SpecialisedSoldier : Private, ISpecialisedSoldier
    {

        private string corps;
        public SpecialisedSoldier(string firstName, string lastName, string id, decimal salary, string corps) : base(firstName, lastName, id, salary)
        {
            Corps = corps;
        }

        public string Corps
        {
            get => corps;

            private set
            {
                if (value == "Airforces" || value == "Marines")
                {
                    corps = value;
                } else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
