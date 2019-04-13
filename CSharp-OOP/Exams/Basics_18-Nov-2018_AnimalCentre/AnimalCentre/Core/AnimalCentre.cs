using AnimalCentre.Factories;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private Hotel hotel;
        private AnimalFactory animalFactory;
        private Dictionary<string, Procedure> procedures;
        private Dictionary<string, List<string>> adoptedAnimalsByOwner;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.animalFactory = new AnimalFactory();
            this.adoptedAnimalsByOwner = new Dictionary<string, List<string>>();
            this.GenerateProcedures();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var newAnimal = animalFactory.Create(type, name, energy, happiness, procedureTime);

            if (hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} already exist");
            }

            hotel.Accommodate(newAnimal);
            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            var currentAnimal = GetAnimal(name);
            this.procedures["Chip"].DoService(currentAnimal, procedureTime);
            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            var currentAnimal = GetAnimal(name);
            this.procedures["Vaccinate"].DoService(currentAnimal, procedureTime);
            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            var currentAnimal = GetAnimal(name);
            this.procedures["Fitness"].DoService(currentAnimal, procedureTime);
            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            var currentAnimal = GetAnimal(name);
            this.procedures["Play"].DoService(currentAnimal, procedureTime);
            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            var currentAnimal = GetAnimal(name);
            this.procedures["DentalCare"].DoService(currentAnimal, procedureTime);
            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            var currentAnimal = GetAnimal(name);
            this.procedures["NailTrim"].DoService(currentAnimal, procedureTime);
            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            var animalToAdopt = GetAnimal(animalName);
            var chipStatusPrefix = animalToAdopt.IsChipped ? "with" : "without";
            this.AddAnimalToAddoptedList(animalName, owner);
            this.hotel.Adopt(animalName, owner);
            return $"{owner} adopted animal {chipStatusPrefix} chip";
        }

        public string History(string type)
        {
            return this.procedures[type].History();
        }

        public string GetOwnersInfo()
        {
            var sb = new StringBuilder();

            foreach (var owner in this.adoptedAnimalsByOwner.OrderBy(o => o.Key))
            {
                sb.AppendLine($"--Owner: {owner.Key}");
                sb.AppendLine($"    - Adopted animals: {string.Join(' ', owner.Value)}");
            }

            return sb.ToString().TrimEnd();
        }

        private IAnimal GetAnimal(string name)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            return this.hotel.Animals[name];
        }

        private void GenerateProcedures()
        {
            this.procedures = new Dictionary<string, Procedure>();

            this.procedures.Add("Chip", new Chip());
            this.procedures.Add("DentalCare", new DentalCare());
            this.procedures.Add("Fitness", new Fitness());
            this.procedures.Add("NailTrim", new NailTrim());
            this.procedures.Add("Play", new Play());
            this.procedures.Add("Vaccinate", new Vaccinate());
        }

        private void AddAnimalToAddoptedList(string animalName, string owner)
        {
            if (!this.adoptedAnimalsByOwner.ContainsKey(owner))
            {
                this.adoptedAnimalsByOwner.Add(owner, new List<string>());
            }

            this.adoptedAnimalsByOwner[owner].Add(animalName);
        }
    }
}
