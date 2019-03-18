using P03.WildFarm.Animals.Birds;
using P03.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Animals
{
    public abstract class Animal
    {
        public string Name { get; protected set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }
        protected double WeightModifier { get; set; }

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public virtual void Eat(Food food)
        {
            if (this.WeightModifier == 0)
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public abstract string ProduceSound();
    }
}
