namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name ==unitType);

            if(type == null)
            {
                throw new ArgumentException("Invalid unit type provided!");
            }

            return (IUnit)Activator.CreateInstance(type);

        }
    }
}
