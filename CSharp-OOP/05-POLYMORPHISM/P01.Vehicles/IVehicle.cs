using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double TankCapacity { get; }
        bool IsEmpty { get; set; }

        string Drive(double distance);
        void Refuel(double fuel);
    }
}
