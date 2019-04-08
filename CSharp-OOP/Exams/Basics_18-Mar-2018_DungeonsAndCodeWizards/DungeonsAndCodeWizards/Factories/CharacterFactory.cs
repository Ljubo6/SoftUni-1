using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character Create(string type, string name, Faction faction)
        {
            var instanceType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            if(instanceType == null)
            {
                throw new ArgumentException($"Invalid character type \"{type}\"");
            }

            var instance = (Character)Activator.CreateInstance(instanceType, new object[] { name, faction });
            return instance;
        }
    }
}
