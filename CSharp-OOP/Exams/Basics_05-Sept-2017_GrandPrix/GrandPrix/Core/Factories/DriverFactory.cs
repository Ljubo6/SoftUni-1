namespace GrandPrix.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class DriverFactory
    {
        public Driver CreateDriver(string type, params object[] args)
        {
            var driverType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type + "Driver");

            if (driverType == null)
            {
                return null;
            }

            var driver = (Driver)Activator.CreateInstance(driverType, args);
            return driver;
        }
    }
}
