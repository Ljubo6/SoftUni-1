using P08.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P08.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.Set = new List<IPrivate>();
        }

        public ICollection<IPrivate> Set { get; private set; }

        public void AddPrivate(ICollection<IPrivate> privates, string id)
        {
            this.Set.Add(privates.Where(x => x.Id == id).FirstOrDefault());
        }

        public override string ToString()
        {
            var lieutenantInfo = new StringBuilder();
            lieutenantInfo.AppendLine(base.ToString());
            lieutenantInfo.AppendLine("Privates:");
            foreach (var privateUnderCommand in this.Set)
            {
                lieutenantInfo.AppendLine($"  {privateUnderCommand.ToString()}");
            }
            return lieutenantInfo.ToString().TrimEnd();
        }
    }
}
