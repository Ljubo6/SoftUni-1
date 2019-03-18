using P08.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps { get; set; }

        public override string ToString()
        {
            var info = new StringBuilder();
            info.AppendLine(base.ToString());
            info.Append($"Corps: {this.Corps}");
            return info.ToString();
        }
    }
}
