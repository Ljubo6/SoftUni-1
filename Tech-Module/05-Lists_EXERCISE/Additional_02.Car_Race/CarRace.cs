using System;
using System.Linq;

namespace Additional_02.Car_Race
{
    class CarRace
    {
        static void Main(string[] args)
        {
            int[] timeNeeded = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int finishLineIndex = timeNeeded.Length / 2;
            double totalTimeFirstRacer = 0.0;
            double totalTimeSecondRacer = 0.0;

            //first racer
            for (int i = 0; i < finishLineIndex; i++)
            {
                totalTimeFirstRacer += timeNeeded[i];
                if (timeNeeded[i] == 0)
                {
                    totalTimeFirstRacer *= 0.8;
                }
            }

            //second racer
            for (int i = timeNeeded.Length - 1; i > finishLineIndex; i--)
            {
                totalTimeSecondRacer += timeNeeded[i];
                if (timeNeeded[i] == 0)
                {
                    totalTimeSecondRacer *= 0.8;
                }
            }

            if (totalTimeFirstRacer < totalTimeSecondRacer)
            {
                Console.WriteLine($"The winner is left with total time: {totalTimeFirstRacer}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {totalTimeSecondRacer}");
            }
        }
    }
}
