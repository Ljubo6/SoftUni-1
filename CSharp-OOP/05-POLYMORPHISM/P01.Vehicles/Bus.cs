using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
    public class Bus : Vehicle
    {
        private const double extraConsumption = 1.4;
        private readonly double initialConsumption;

        public override bool IsEmpty { get; set; }

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.initialConsumption = fuelConsumption;
        }

        public override string Drive(double distance)
        {
            if (IsEmpty == false)
            {
                this.FuelConsumption += extraConsumption;
            }
            else
            {
                this.FuelConsumption = initialConsumption;
            }
            return base.Drive(distance);
        }
    }
}
