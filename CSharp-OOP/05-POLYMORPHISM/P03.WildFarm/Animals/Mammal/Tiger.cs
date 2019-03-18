using System;
using System.Collections.Generic;
using System.Text;
using P03.WildFarm.Foods;

namespace P03.WildFarm.Animals.Mammal
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                this.WeightModifier = 1;
                this.FoodEaten += food.Quantity;
            }
            base.Eat(food);
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
