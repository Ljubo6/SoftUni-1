using System;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;

    public Engine(DraftManager draftManager)
    {
        this.draftManager = draftManager;
    }

    public void Run()
    {
        var output = string.Empty;

        while (true)
        {
            var input = Console.ReadLine();

            if (input == "Shutdown")
            {
                output = this.draftManager.ShutDown();
                Console.WriteLine(output);
                return;
            }

            var command = input.Split().Take(1).First().ToString();
            var arguments = input.Split().Skip(1).ToList();

            switch (command)
            {
                case "RegisterHarvester":
                    output = this.draftManager.RegisterHarvester(arguments);
                    break;
                case "RegisterProvider":
                    output = this.draftManager.RegisterProvider(arguments);
                    break;
                case "Day":
                    output = this.draftManager.Day();
                    break;
                case "Mode":
                    output = this.draftManager.Mode(arguments);
                    break;
                case "Check":
                    output = this.draftManager.Check(arguments);
                    break;
                default:
                    break;
            }

            Console.WriteLine(output);
        }

    }
}

