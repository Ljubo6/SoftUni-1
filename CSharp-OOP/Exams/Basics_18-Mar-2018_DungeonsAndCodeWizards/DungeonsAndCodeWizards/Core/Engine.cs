using DungeonsAndCodeWizards.Core.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private CommandInterpreter commandInterpreter;
        private DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
            this.commandInterpreter = new CommandInterpreter(dungeonMaster);
        }

        public void Run()
        {
            string input = ConsoleReader.Read();

            while (true)
            {
                if (string.IsNullOrEmpty(input))
                {
                    this.EndGame();
                    return;
                }

                ConsoleWriter.Write(commandInterpreter.Interprete(input));

                if (this.dungeonMaster.IsGameOver())
                {
                    this.EndGame();
                    return;
                }

                input = ConsoleReader.Read();
            }
        }

        private void EndGame()
        {
            ConsoleWriter.Write("Final stats:");
            ConsoleWriter.Write(this.dungeonMaster.GetStats());
        }
    }
}
