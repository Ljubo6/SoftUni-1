using GrandPrix.Core;

public class StartUp
{
    public static void Main(string[] args)
    {
        var raceTower = new RaceTower();
        var commandExecutor = new CommandExecuter(raceTower);

        var engine = new Engine(commandExecutor, raceTower);
        engine.Run();
    }
}
