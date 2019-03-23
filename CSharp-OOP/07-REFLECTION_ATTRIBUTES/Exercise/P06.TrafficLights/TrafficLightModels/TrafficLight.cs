using System;
using System.Collections.Generic;
using System.Text;

namespace P06.TrafficLights.TrafficLightModels
{
    public class TrafficLight : ITrafficLight
    {
        public TrafficLight(State state)
        {
            this.State = state;
        }

        public State State { get; set; }

        public void ChangeState(int cycles)
        {
            var newStateValue = ((int)this.State + cycles) % 3;
            this.State = (State)newStateValue;
        }
    }
}
