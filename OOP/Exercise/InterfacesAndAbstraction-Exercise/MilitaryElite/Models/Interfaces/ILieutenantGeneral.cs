using System.Collections.Generic;

namespace MilitaryElite.Models.Interfaces
{
    internal interface ILieutenantGeneral : IPrivate
    {
        public List<ISoldier> Privates { get; }
    }
}
