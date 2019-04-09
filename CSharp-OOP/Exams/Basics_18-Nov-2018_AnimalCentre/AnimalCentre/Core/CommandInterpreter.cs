using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Core
{
    public class CommandInterpreter
    {
        private readonly AnimalCentre animalCentre;

        public CommandInterpreter(AnimalCentre animalCentre)
        {
            this.animalCentre = animalCentre;
        }

        public string ExecuteCommand(string input)
        {
            var data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var commandString = data[0];
            var args = data.Skip(1).ToArray();

            var output = string.Empty;

            switch (commandString)
            {
                case "RegisterAnimal":
                    string type = args[0];
                    string name = args[1];
                    int energy = int.Parse(args[2]);
                    int happiness = int.Parse(args[3]);
                    int procedureTime = int.Parse(args[4]);
                    output = this.animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);
                    break;
                case "Chip":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);
                    output = this.animalCentre.Chip(name, procedureTime);
                    break;
                case "Vaccinate":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);
                    output = this.animalCentre.Vaccinate(name, procedureTime);
                    break;
                case "Fitness":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);
                    output = this.animalCentre.Fitness(name, procedureTime);
                    break;
                case "Play":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);
                    output = this.animalCentre.Play(name, procedureTime);
                    break;
                case "DentalCare":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);
                    output = this.animalCentre.DentalCare(name, procedureTime);
                    break;
                case "NailTrim":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);
                    output = this.animalCentre.NailTrim(name, procedureTime);
                    break;
                case "Adopt":
                    name = args[0];
                    string owner = args[1];
                    output = this.animalCentre.Adopt(name, owner);
                    break;
                case "History":
                    var procedureType = args[0];
                    output = this.animalCentre.History(procedureType);
                    break;
                default:
                    break;
            }

            return output;
        }
    }
}
