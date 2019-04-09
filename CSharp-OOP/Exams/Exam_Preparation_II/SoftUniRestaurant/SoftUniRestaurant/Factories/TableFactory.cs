namespace SoftUniRestaurant.Factories
{
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class TableFactory
    {
        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            var tableType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type + "Table");

            var instance = (ITable)Activator.CreateInstance(tableType, new object[] { tableNumber, capacity });
            return instance;
        }
    }
}
