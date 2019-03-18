using P08.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite.Contracts
{
    public interface ICommando
    {
        ICollection<Mission> Missions { get; }
        void CompleteMission(string missionName);
    }
}
