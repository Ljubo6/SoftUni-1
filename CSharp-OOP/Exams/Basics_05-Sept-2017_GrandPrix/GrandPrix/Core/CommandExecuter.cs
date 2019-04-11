using System.Linq;

namespace GrandPrix.Core
{
    public class CommandExecuter
    {
        private RaceTower raceTower;

        public CommandExecuter (RaceTower raceTower)
        {
            this.raceTower = raceTower;
        }

        public string Execute(string[] input)
        {
            var commandInput = input[0];
            var args = input.Skip(1).ToList();

            switch (commandInput)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(args);
                    return null;
                case "Leaderboard":
                    return this.raceTower.GetLeaderboard();
                case "CompleteLaps":
                    return this.raceTower.CompleteLaps(args);
                case "Box":
                    this.raceTower.DriverBoxes(args);
                    return null;
                case "ChangeWeather":
                    this.raceTower.ChangeWeather(args);
                    return null;
                default:
                    return null;
            }
        }
    }
}
