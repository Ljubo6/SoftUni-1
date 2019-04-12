using GrandPrix.CustomExceptions;
using System;
using System.Linq;

public class CommandExecuter
{
    private RaceTower raceTower;

    public CommandExecuter(RaceTower raceTower)
    {
        this.raceTower = raceTower;
    }

    public void Execute(string[] input)
    {
        var commandInput = input[0];
        var args = input.Skip(1).ToList();

        switch (commandInput)
        {
            case "RegisterDriver":
                this.raceTower.RegisterDriver(args);
                break;
            case "Leaderboard":
                Console.WriteLine(this.raceTower.GetLeaderboard());
                break;
            case "CompleteLaps":
                try
                {
                    var output = this.raceTower.CompleteLaps(args);

                    if(output != null)
                    {
                        Console.WriteLine(output);
                    }
                }
                catch (WrongLapCountException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            case "Box":
                this.raceTower.DriverBoxes(args);
                break;
            case "ChangeWeather":
                this.raceTower.ChangeWeather(args);
                break;
            default:
                break;
        }
    }
}
