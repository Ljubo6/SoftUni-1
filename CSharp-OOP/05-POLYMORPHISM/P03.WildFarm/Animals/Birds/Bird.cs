using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Animals.Birds
{
    public abstract class Bird : Animal 
    {
        public Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; protected set; }

        public override string ToString()
        {
            double weightGained = this.WeightModifier * this.FoodEaten;
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight + weightGained}, {this.FoodEaten}]";
        }
    }
}
