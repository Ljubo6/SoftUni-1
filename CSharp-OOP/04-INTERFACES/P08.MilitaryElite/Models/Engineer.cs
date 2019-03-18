using P08.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs { get; private set; }

        public void AddRepair(IRepair repair)
        {
            this.Repairs.Add(repair);
        }

        public override string ToString()
        {
            var engineerInfo = new StringBuilder();
            engineerInfo.AppendLine(base.ToString());
            engineerInfo.AppendLine("Repairs:");
            foreach (var partRepair in this.Repairs)
            {
                engineerInfo.AppendLine($"  {partRepair.ToString()}");
            }
            return engineerInfo.ToString().TrimEnd();
        }
    }
}
