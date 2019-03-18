using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
    public class Truck : Vehicle
    {
        private const string type = "Truck";
        private const double extraConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += extraConsumption;
        }
    }
}
