namespace DungeonsAndCodeWizards.Core
{
    using DungeonsAndCodeWizards.Contracts;
    using DungeonsAndCodeWizards.Core.IO;

    public class Engine
    {
        private ICommandInterpreter commandInterpreter;
        private IDungeonMaster dungeonMaster;

        public Engine(ICommandInterpreter commandInterpreter, IDungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
            this.commandInterpreter = commandInterpreter;
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
