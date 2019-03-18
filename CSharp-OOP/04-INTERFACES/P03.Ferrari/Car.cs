using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Ferrari
{
    public class Car : ICar
    {
        public Car(string make, string model)
        {
            this.Make = make;
            this.Model = model;
        }

        public string Make { get; private set; }

        public string Model { get; private set; }

        public string Driver { get; set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string GasPedal()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{Model}/{Brakes()}/{GasPedal()}/{Driver}";
        }
    }
}
