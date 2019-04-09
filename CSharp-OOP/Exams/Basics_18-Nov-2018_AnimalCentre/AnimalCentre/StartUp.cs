using AnimalCentre.Core;
using System;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animalCentre = new Core.AnimalCentre();
            var commandInterpreter = new CommandInterpreter(animalCentre);
            var engine = new Engine(commandInterpreter, animalCentre);
            engine.Run();

        }
    }
}
