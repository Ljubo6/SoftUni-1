using P07.InfernoInfinity.Attributes;
using P07.InfernoInfinity.Contracts;
using System;

namespace P07.InfernoInfinity.Core
{
    public class Engine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(IWeaponFactory weaponFactory, IGemFactory gemFactory, IRepository repository)
        {
            this.commandInterpreter = new CommandInterpreter(weaponFactory, gemFactory, repository);
        }

        public void Run()
        {
            while (true)
            {
                string[] data = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var commandName = data[0];

                if (commandName == "END")
                {
                    return;
                }

                try
                {
                    var command = commandInterpreter.InterpreteData(commandName, data);
                    command.Execute();
                }
                catch(Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
                
            }
        }
    }
}
