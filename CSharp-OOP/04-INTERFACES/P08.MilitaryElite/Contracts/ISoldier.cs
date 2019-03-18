using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite.Contracts
{
    public interface ISoldier
    {
        string Id { get; }
        string FirstName { get; }
        string LastName { get; }
    }
}
