using System;
using System.Linq;
using System.Reflection;

namespace GrandPrix.Core.Factories
{
    public class TyreFactory
    {
        public Tyre CreateTyre(string type, params object[] args)
        {
            var tyreType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type + "Tyre");

            if(tyreType == null)
            {
                return null;
            }

            var tyre = (Tyre)Activator.CreateInstance(tyreType, args);
            return tyre;
        }
    }
}
