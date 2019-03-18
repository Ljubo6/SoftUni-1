using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.Truck_Tour
{
    class TruckTour
    {
        public static void Main(string[] args)
        {
            Queue<Station> pumps = new Queue<Station>();

            int pumpsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < pumpsCount; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                Station currentPump = new Station()
                {
                    NewPetrol = input[0],
                    DistanceToNextStation = input[1]
                };

                pumps.Enqueue(currentPump);
            }

            int tank = 0;
            int totalPumpsVisited = 0;
            int count = 0;


            while (count != pumpsCount)
            {
                tank += pumps.Peek().NewPetrol;
                int distance = pumps.Peek().DistanceToNextStation;
                pumps.Enqueue(pumps.Dequeue());
                totalPumpsVisited++;

                if (tank >= distance)
                {
                    count++;
                    tank -= distance;
                }
                else
                {
                    tank = 0;
                    count = 0;
                }
            }

            Console.WriteLine(totalPumpsVisited % pumpsCount);
        }
    }

    public class Station
    {
        public int NewPetrol { get; set; }
        public int DistanceToNextStation { get; set; }
    }
}
