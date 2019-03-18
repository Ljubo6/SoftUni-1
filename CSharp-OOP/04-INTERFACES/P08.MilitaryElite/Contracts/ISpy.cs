using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite.Contracts
{
    public interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }
}
