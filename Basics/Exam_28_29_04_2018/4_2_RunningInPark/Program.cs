using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_2_RunningInPark
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalTimeRunning = 0;
            double totalDistance = 0.0;

            for (int i = 1; i <= n; i++)
            {
                int timeRunning = int.Parse(Console.ReadLine());
                double distance = double.Parse(Console.ReadLine());
                string measure = Console.ReadLine();


                if (measure == "m")
                {
                    distance = distance / 1000.00;
                }
                totalDistance += distance;
                totalTimeRunning += timeRunning;

                
            }
            double Callories = totalTimeRunning * 20.0;
            Console.WriteLine($"He ran {totalDistance:f2}km for {totalTimeRunning} minutes and burned {Callories} calories.");
            
            


        }
    }
}
