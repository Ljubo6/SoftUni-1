namespace DungeonsAndCodeWizards
{
    using DungeonsAndCodeWizards.Contracts;
    using DungeonsAndCodeWizards.Core;

    public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main(string[] args)
		{
            IDungeonMaster dungeonMaster = new DungeonMaster();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(dungeonMaster);

            var engine = new Engine(commandInterpreter, dungeonMaster);
            engine.Run();
		}
	}
}