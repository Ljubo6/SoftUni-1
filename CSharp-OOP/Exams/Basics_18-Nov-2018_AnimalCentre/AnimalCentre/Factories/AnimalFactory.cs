using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Factories
{
    public class AnimalFactory
    {
        public IAnimal Create(string type, string name, int energy, int happiness, int procedureTime)
        {
            var instanceType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            if(instanceType == null)
            {
                throw new ArgumentException("Invalid animal type!");
            }

            var instance = (IAnimal)Activator.CreateInstance(instanceType, new object[] { name, energy, happiness, procedureTime });
            return instance;
        }
    }
}
