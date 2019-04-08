using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item Create(string itemName)
        {
            var instanceType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == itemName);

            if (instanceType == null)
            {
                throw new ArgumentException($"Invalid item \"{itemName}\"");
            }

            var instance = (Item)Activator.CreateInstance(instanceType);
            return instance;
        }
    }
}
