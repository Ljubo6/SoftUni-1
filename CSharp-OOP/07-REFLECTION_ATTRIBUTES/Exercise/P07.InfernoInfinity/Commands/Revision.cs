using System;
using System.Collections.Generic;
using System.Text;

namespace P07.InfernoInfinity.Commands
{
    public class Revision : RetrieveClassWeaponAttributeInfo
    {
        public Revision(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            this.Print(this.AttributeType.Revision.ToString());
        }
    }
}
