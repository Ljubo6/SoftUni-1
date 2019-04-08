namespace AnimalCentre.Models.Hotels
{
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;

    public class Hotel : IHotel
    {
        private const int Capacity = 10;
        private Dictionary<string, IAnimal> hotel;

        public Hotel()
        {
            this.hotel = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => this.hotel;

        public void Accommodate(IAnimal animal)
        {
            this.ValidateHotelCapacity();
            this.CheckForAnimalWithSameName(animal.Name);

            this.hotel.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            this.CheckForAnimalInHotel(animalName);
            this.AddoptAnimal(animalName, owner);
        }

        private void AddoptAnimal(string animalName, string owner)
        {
            this.hotel[animalName].Owner = owner;
            this.hotel[animalName].IsAdopt = true;
            this.hotel.Remove(animalName);
        }

        private void CheckForAnimalInHotel(string animalName)
        {
            if (!this.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
        }

        private void ValidateHotelCapacity()
        {
            if(this.hotel.Count >= Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
        }

        private void CheckForAnimalWithSameName(string animalName)
        {
            if (this.hotel.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} already exist");
            }
        }
    }
}
