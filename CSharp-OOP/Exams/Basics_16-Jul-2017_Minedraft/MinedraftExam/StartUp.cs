public class StartUp
{
    public static void Main(string[] args)
    {
        DraftManager draftManager = new DraftManager();
        Engine engine = new Engine(draftManager);
        engine.Run();
    }
}
