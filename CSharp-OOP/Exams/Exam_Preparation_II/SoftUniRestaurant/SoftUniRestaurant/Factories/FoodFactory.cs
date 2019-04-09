namespace SoftUniRestaurant.Factories
{
    using SoftUniRestaurant.Models.Foods.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class FoodFactory
    {
        public IFood CreateFood(string type, string name, decimal price)
        {
            var foodType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            var instance = (IFood)Activator.CreateInstance(foodType, new object[] { name, price });
            return instance;
        }
    }
}
