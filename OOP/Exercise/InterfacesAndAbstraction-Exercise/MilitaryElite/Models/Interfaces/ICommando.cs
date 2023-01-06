using System.Collections.Generic;

namespace MilitaryElite.Models.Interfaces
{
    internal interface ICommando : ISpecialisedSoldier
    {
        List<Mission> Missions { get; }
    }
}
