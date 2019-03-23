using P06.TrafficLights.TrafficLightModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace P06.TrafficLights.Core
{
    public class Engine
    {
        public void Run()
        {
            var factory = new TrafficLightFactory();
            List<ITrafficLight> allTrafficLights = new List<ITrafficLight>();

            string[] colorUponInitialisation = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int cycles = int.Parse(Console.ReadLine());

            foreach (string color in colorUponInitialisation)
            {
                var newTrafficLight = factory.Create(color);
                allTrafficLights.Add(newTrafficLight);
            }

            for (int i = 0; i < cycles; i++)
            {
                var sb = new StringBuilder();

                foreach (ITrafficLight trafficLight in allTrafficLights)
                {
                    trafficLight.ChangeState(1);
                    sb.Append(trafficLight.State + " ");
                }

                Console.WriteLine(sb.ToString().TrimEnd());
            }

            
        }
    }
}
