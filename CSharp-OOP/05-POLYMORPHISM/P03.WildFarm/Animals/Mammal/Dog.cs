using System;
using System.Collections.Generic;
using System.Text;
using P03.WildFarm.Foods;

namespace P03.WildFarm.Animals.Mammal
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                this.WeightModifier = 0.4;
                this.FoodEaten += food.Quantity;
            }
            base.Eat(food);
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
