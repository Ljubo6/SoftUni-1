namespace SoftUniRestaurant.Factories
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class DrinkFactory
    {
        public IDrink CreateFood(string type, string name, int servingSize, string brand)
        {
            var drinkType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            var instance = (IDrink)Activator.CreateInstance(drinkType, new object[] { name, servingSize, brand });
            return instance;
        }
    }
}
