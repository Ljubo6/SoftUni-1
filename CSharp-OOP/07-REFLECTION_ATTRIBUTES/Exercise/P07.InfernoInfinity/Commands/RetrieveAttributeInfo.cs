using P07.InfernoInfinity.Attributes;
using P07.InfernoInfinity.Models.Weapons;
using System;
using System.Linq;

namespace P07.InfernoInfinity.Commands
{
    public abstract class RetrieveClassWeaponAttributeInfo : Command
    {
        protected RetrieveClassWeaponAttributeInfo(string[] data) : base(data)
        {
        }

        protected ReviewAttribute AttributeType
        {
            get
            {
                var type = typeof(Weapon);
                var attribute = (ReviewAttribute)type.GetCustomAttributes(false).FirstOrDefault();
                return attribute;
            }
        }

        protected void Print(string attributeValue)
        {
            Console.WriteLine($"{this.GetType().Name}: {attributeValue}");
        }
    }
}
