using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RunningInThePark
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalkCals = 0;
            int totalTimeRunning = 0;
            double totalDistance = 0.0;
            for (int i = 0; i < n; i++)
            {
                int minutesRunning = int.Parse(Console.ReadLine());
                double distance = double.Parse(Console.ReadLine());
                string unit = Console.ReadLine();

                int kcals = minutesRunning * 20;
                totalkCals = totalkCals + kcals;
                totalTimeRunning = totalTimeRunning + minutesRunning;

                if (unit == "m")
                {
                    distance = distance / 1000.0;
                }
                totalDistance = totalDistance + distance;
            }
            Console.WriteLine($"He ran {totalDistance:f2}km for {totalTimeRunning} minutes and burned {totalkCals} calories.");
        }
    }
}
