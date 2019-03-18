using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Animals.Mammal
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; protected set; }

        public override string ToString()
        {
            double weightGained = this.WeightModifier * this.FoodEaten;
            return $"{this.GetType().Name} [{this.Name}, {this.Weight + weightGained}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
