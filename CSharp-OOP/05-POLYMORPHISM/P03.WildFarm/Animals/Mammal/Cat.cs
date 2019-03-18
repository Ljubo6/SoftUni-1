using System;
using System.Collections.Generic;
using System.Text;
using P03.WildFarm.Foods;

namespace P03.WildFarm.Animals.Mammal
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                this.WeightModifier = 0.3;
                this.FoodEaten += food.Quantity;
            }
            base.Eat(food);
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
