namespace MilitaryElite.Models
{
    using Interfaces;
    internal class Private : Soldier, IPrivate
    {
        public Private(string firstName, string lastName, string id, decimal salary) : base(firstName, lastName, id)
        {
            Salary = salary;
        }
        public decimal Salary { get; private set;}

        public override string ToString() => $"{base.ToString()} Salary: {Salary:F2}";
    }
}
