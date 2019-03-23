namespace _03.BarracksWars.Core
{
    using _03BarracksFactory.Contracts;
    using _03BarracksWars.Attributes;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            commandName = commandName[0].ToString().ToUpper() + commandName.Substring(1).ToString().ToLower();
            var commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName);

            if(commandType == null)
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
