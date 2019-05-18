using P01.Chronometer.ChronometerModel;
using System;

namespace P01_Chronometer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var chronometer = new Chronometer();

            while (true)
            {
                var command = Console.ReadLine();

                switch (command)
                {
                    case "start":
                        chronometer.Start();
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "lap":
                        Console.WriteLine(chronometer.Lap());
                        break;
                    case "laps":
                        Console.WriteLine(chronometer.GetLaps());
                        break;
                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
