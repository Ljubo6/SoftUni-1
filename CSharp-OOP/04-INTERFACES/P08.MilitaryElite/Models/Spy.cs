using P08.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $" Code Number: {this.CodeNumber}";
        }
    }
}
