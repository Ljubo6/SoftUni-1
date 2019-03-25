using P07.InfernoInfinity.Attributes;
using P07.InfernoInfinity.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace P07.InfernoInfinity.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IWeaponFactory weaponFactory;
        private IGemFactory gemFactory;
        private IRepository repository;

        public CommandInterpreter(IWeaponFactory weaponFactory, IGemFactory gemFactory, IRepository repository)
        {
            this.weaponFactory = weaponFactory;
            this.gemFactory = gemFactory;
            this.repository = repository;
        }

        public IExecutable InterpreteData(string commandName, string[] data)
        {
            commandName = commandName[0].ToString().ToUpper() + commandName.Substring(1).ToString().ToLower();
            var commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var command = (IExecutable)Activator.CreateInstance(commandType, new object[] { data });
            this.InjectFields(command);
            return command;
        }

        private void InjectFields(IExecutable command)
        {
            var injectionType = typeof(InjectAttribute);

            var fieldsToInject = command
                .GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.GetCustomAttributes().Any(f => f.GetType() == injectionType));

            var interpreterFields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);


            foreach (var field in fieldsToInject)
            {
                var interpreterField = interpreterFields.FirstOrDefault(x => x.FieldType == field.FieldType).GetValue(this);
                field.SetValue(command, interpreterField);
            }
        }
    }
}
