using System;
using System.Collections.Generic;
using System.Text;

namespace P07.InfernoInfinity.Commands
{
    class Author : RetrieveClassWeaponAttributeInfo
    {
        public Author(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            this.Print(this.AttributeType.Author);
        }
    }
}
