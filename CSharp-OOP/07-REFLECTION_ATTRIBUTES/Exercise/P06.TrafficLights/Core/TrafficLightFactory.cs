using P06.TrafficLights.TrafficLightModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P06.TrafficLights.Core
{
    public class TrafficLightFactory
    {
        public ITrafficLight Create(string color)
        {
            color = color[0].ToString().ToUpper() + color.Substring(1).ToString().ToLower();
            var state = Enum.Parse(typeof(State), color);
            var type = typeof(TrafficLight);
            var instance = (ITrafficLight)Activator.CreateInstance(type, new[] { state });
            return instance;
        }
    }
}
