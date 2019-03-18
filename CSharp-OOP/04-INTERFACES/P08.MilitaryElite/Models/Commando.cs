using P08.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P08.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public ICollection<Mission> Missions { get; private set; }

        public void AddMission(Mission mission)
        {
            this.Missions.Add(mission);
        }

        public void CompleteMission(string missionName)
        {
            var mission = this.Missions.FirstOrDefault(x => x.CodeName == missionName);
            if(mission != null)
            {
                mission.State = "Finished";
            }
        }

        public override string ToString()
        {
            var commandoInfo = new StringBuilder();
            commandoInfo.AppendLine(base.ToString());
            commandoInfo.AppendLine("Missions:");
            foreach (var mission in this.Missions)
            {
                commandoInfo.AppendLine($"  {mission.ToString()}");
            }
            return commandoInfo.ToString().TrimEnd();
        }
    }
}
