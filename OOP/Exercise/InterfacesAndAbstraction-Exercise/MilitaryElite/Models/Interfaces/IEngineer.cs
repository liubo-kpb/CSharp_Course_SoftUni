using System.Collections.Generic;

namespace MilitaryElite.Models.Interfaces
{
    internal interface IEngineer : ISpecialisedSoldier
    {
        List<Repair> Repairs { get; }
    }
}
