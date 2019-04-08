using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class CommandInterpreter
    {
        private readonly DungeonMaster dungeonMaster;

        public CommandInterpreter(DungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
        }

        public string Interprete(string input)
        {
            var data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var commandString = data[0];

            //if(commandString == "GetStats")
            //{
            //    return this.dungeonMaster.GetStats();
            //}

            var args = data.Skip(1).ToArray();

            var command = typeof(DungeonMaster)
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
                .FirstOrDefault(m => m.Name == commandString);

            if (command == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            string output = string.Empty;

            try
            {
                if (command.GetParameters().Count() == 0)
                {
                    output = command.Invoke(dungeonMaster, new object[0]).ToString();
                }
                else
                {
                    output = command.Invoke(dungeonMaster, new object[] { args }).ToString();
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException is InvalidOperationException operationEx)
                {
                    return $"Invalid Operation: {operationEx.Message}";
                }
                else if (ex.InnerException is ArgumentException argEx)
                {
                    return $"Parameter Error: {argEx.Message}";
                }
            }
            return output;
        }
    }
}
