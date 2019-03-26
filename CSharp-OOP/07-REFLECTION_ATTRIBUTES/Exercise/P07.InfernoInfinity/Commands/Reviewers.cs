using System;
using System.Collections.Generic;
using System.Text;

namespace P07.InfernoInfinity.Commands
{
    public class Reviewers : RetrieveClassWeaponAttributeInfo
    {
        public Reviewers(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            this.Print(string.Join(", ", this.AttributeType.Reviewers));
        }
    }
}
