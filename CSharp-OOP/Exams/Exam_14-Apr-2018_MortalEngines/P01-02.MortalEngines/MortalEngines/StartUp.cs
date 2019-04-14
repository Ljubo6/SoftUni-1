using MortalEngines.Core;
using System;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            var machineManager = new MachinesManager();

            while (true)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];
                if(command == "Quit")
                {
                    return;
                }

                var output = string.Empty;

                switch (command)
                {
                    case "HirePilot":
                        output = machineManager.HirePilot(input[1]);
                        break;
                    case "PilotReport":
                        output = machineManager.PilotReport(input[1]);
                        break;
                    case "ManufactureTank":
                        output = machineManager.ManufactureTank(input[1], double.Parse(input[2]), double.Parse(input[3]));
                        break;
                    case "ManufactureFighter":
                        output = machineManager.ManufactureFighter(input[1], double.Parse(input[2]), double.Parse(input[3]));
                        break;
                    case "MachineReport":
                        output = machineManager.MachineReport(input[1]);
                        break;
                    case "AggressiveMode":
                        output = machineManager.ToggleFighterAggressiveMode(input[1]);
                        break;
                    case "DefenseMode":
                        output = machineManager.ToggleTankDefenseMode(input[1]);
                        break;
                    case "Engage":
                        output = machineManager.EngageMachine(input[1], input[2]);
                        break;
                    case "Attack":
                        output = machineManager.AttackMachines(input[1], input[2]);
                        break;
                    default:
                        break;
                }

                Console.WriteLine(output);
            }
        }
    }
}