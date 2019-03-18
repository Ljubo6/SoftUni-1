using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Animals.Mammal
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; protected set; }

        public override string ToString()
        {
            double weightGained = this.WeightModifier * this.FoodEaten;
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight + weightGained}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
