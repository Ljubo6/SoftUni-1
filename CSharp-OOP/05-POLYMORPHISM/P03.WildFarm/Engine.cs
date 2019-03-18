using P03.WildFarm.Animals;
using P03.WildFarm.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm
{
    public static class Engine
    {
        public static void Run()
        {
            List<Animal> allAnimals = new List<Animal>();

            while (true)
            {
                string input = Console.ReadLine();

                var animalFactory = new AnimalFactory();
                var foodFactory = new FoodFactory();

                if (input == "End")
                {
                    break;
                }

                var currentAnimal = animalFactory.CreateAnimal(input);
                allAnimals.Add(currentAnimal);

                var foodInput = Console.ReadLine();
                var currentFood = foodFactory.MakeFood(foodInput);

                Console.WriteLine(currentAnimal.ProduceSound());

                try
                {
                    currentAnimal.Eat(currentFood);
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var animal in allAnimals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
