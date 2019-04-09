using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private CommandInterpreter commandInterpreter;
        private AnimalCentre animalCentre;

        public Engine(CommandInterpreter commandInterpreter, AnimalCentre animalCentre)
        {
            this.commandInterpreter = commandInterpreter;
            this.animalCentre = animalCentre;
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    Console.WriteLine(animalCentre.GetOwnersInfo());
                    return;
                }

                try
                {
                    Console.WriteLine(commandInterpreter.ExecuteCommand(input));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException == null)
                    {
                        Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                    }
                    else
                    {
                        Console.WriteLine($"{ex.InnerException.GetType().Name}: {ex.InnerException.Message}");
                    }
                }
            }
        }
    }
}
