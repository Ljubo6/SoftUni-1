using System;
using System.Collections.Generic;
using System.Text;
using P03.WildFarm.Foods;

namespace P03.WildFarm.Factory
{
   public class FoodFactory
    {
        public Food MakeFood(string input)
        {
            string[] foodData = input.Split();
            string type = foodData[0].ToLower();
            int quantity = int.Parse(foodData[1]);

            switch (type)
            {
                case "vegetable":
                    return new Vegetable(quantity);
                case "fruit":
                    return new Fruit(quantity);
                case "meat":
                    return new Meat(quantity);
                case "seeds":
                    return new Seeds(quantity);
                default:
                    throw new ArgumentException("Invalid food!");
            }
        }
    }
}
