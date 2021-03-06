﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P07.InfernoInfinity.Commands
{
    public class Description : RetrieveClassWeaponAttributeInfo
    {
        public Description(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            var output = "Class description: " + this.AttributeType.Description.ToString();
            Console.WriteLine(output);
        }
    }
}
