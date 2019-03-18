using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        ICollection<IPrivate> Set { get; }
    }
}
