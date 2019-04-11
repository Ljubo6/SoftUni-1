using GrandPrix.Core;
using GrandPrix.Core.Factories;
using System;

namespace GrandPrix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var raceTower = new RaceTower();
            var commandExecutor = new CommandExecuter(raceTower);

            var engine = new Engine(commandExecutor, raceTower);
            engine.Run();
        }
    }
}
