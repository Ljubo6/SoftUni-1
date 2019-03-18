using System;
using System.Collections.Generic;
using System.Text;
using P03.WildFarm.Foods;

namespace P03.WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                this.WeightModifier = 0.25;
                this.FoodEaten += food.Quantity;
            }
            base.Eat(food);
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
