using System;
using System.Collections.Generic;
using System.Text;
using P03.WildFarm.Animals;
using P03.WildFarm.Animals.Birds;
using P03.WildFarm.Animals.Mammal;

namespace P03.WildFarm.Factory
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string input)
        {
            string[] animalInfo = input.Split();
            string type = animalInfo[0].ToLower();
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            if (type == "owl" || type == "hen")
            {
                var wingSize = double.Parse(animalInfo[3]);

                switch (type)
                {
                    case "owl":
                        return new Owl(name, weight, wingSize);
                    case "hen":
                        return new Hen(name, weight, wingSize);
                    default:
                        throw new ArgumentException("Invalid animal input");
                }
            }

            else
            {
                var livingRegion = animalInfo[3];
                var breed = string.Empty;
                if (animalInfo.Length == 5)
                {
                    breed = animalInfo[4];
                }
                switch (type)
                {
                    case "mouse":
                        return new Mouse(name, weight, livingRegion);
                    case "dog":
                        return new Dog(name, weight, livingRegion);
                    case "cat":
                        return new Cat(name, weight, livingRegion, breed);
                    case "tiger":
                        return new Tiger(name, weight, livingRegion, breed);
                    default:
                        throw new ArgumentException("Invalid animal input");
                }
            }
        }
    }
}
