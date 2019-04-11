using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandPrix.Core
{
    public class Engine
    {
        private CommandExecuter commandExecuter;
        private RaceTower raceTower;

        public Engine(CommandExecuter commandExecuter, RaceTower raceTower)
        {
            this.raceTower = raceTower;
            this.commandExecuter = commandExecuter;
        }

        public void Run()
        {
            int totalLaps = int.Parse(Console.ReadLine());
            int trackLength = int.Parse(Console.ReadLine());

            raceTower.SetTrackInfo(totalLaps, trackLength);

            while (true)
            {
                if (raceTower.IsFinished)
                {
                    Console.WriteLine(raceTower.PrintWinner());
                    return;
                }

                var input = Console.ReadLine().Split();
                var result = commandExecuter.Execute(input);

                if(result != null)
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}
