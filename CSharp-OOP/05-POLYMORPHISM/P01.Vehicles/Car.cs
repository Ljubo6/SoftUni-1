using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
   public class Car : Vehicle
    {
        private const string type = "Car";
        private const double extraConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += extraConsumption;
        }
    }
}
