using P06.TrafficLights.Core;
using System;

namespace P06.TrafficLights
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
