using System;

namespace P01.Vehicles
{
    public class StartUp
    {
        public static void Main()
        {
            var carInfo = Console.ReadLine().Split();
            var truckInfo = Console.ReadLine().Split();
            var busInfo = Console.ReadLine().Split();

            IVehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            IVehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            IVehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string type = input[1];
                double distance = double.Parse(input[2]);
                double litters = double.Parse(input[2]);

                try
                {
                    if (command == "Drive")
                    {
                        if (type == "Car")
                        {
                            Console.WriteLine(car.Drive(distance));
                        }
                        else if (type == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                        else if (type == "Bus")
                        {
                            bus.IsEmpty = false;
                            Console.WriteLine(bus.Drive(distance));
                        }
                    }

                    else if (command == "DriveEmpty")
                    {
                        bus.IsEmpty = true;
                        Console.WriteLine(bus.Drive(distance));

                    }

                    else if (command == "Refuel")
                    {
                        if (type == "Car")
                        {
                            car.Refuel(litters);
                        }
                        else if (type == "Truck")
                        {
                            truck.Refuel(litters);
                        }
                        else if (type == "Bus")
                        {
                            bus.Refuel(litters);
                        }
                    }
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
