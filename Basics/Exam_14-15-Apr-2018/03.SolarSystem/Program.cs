using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SolarSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string planet = Console.ReadLine().ToLower();
            int days = int.Parse(Console.ReadLine());
            double distanceFromEarth = 0.0;
            int maxDaysStay = 0;

            switch (planet)
            {
                case "mercury":
                    distanceFromEarth = 0.61;
                    maxDaysStay = 7;
                    break;
                case "venus":
                    distanceFromEarth = 0.28;
                    maxDaysStay = 14;
                    break;
                case "mars":
                    distanceFromEarth = 0.52;
                    maxDaysStay = 20;
                    break;
                case "jupiter":
                    distanceFromEarth = 4.2;
                    maxDaysStay = 5;
                    break;
                case "saturn":
                    distanceFromEarth = 8.52;
                    maxDaysStay = 3;
                    break;
                case "uranus":
                    distanceFromEarth = 18.21;
                    maxDaysStay = 3;
                    break;
                case "neptune":
                    distanceFromEarth = 29.09;
                    maxDaysStay = 2;
                    break;
                default:
                    Console.WriteLine($"Invalid planet name!");
                    break;
            }
            if (planet == "mercury" || planet == "venus" || planet == "mars" || planet == "jupiter" ||
                planet == "saturn" || planet == "uranus" || planet == "neptune")
            {
                
                if (days > maxDaysStay)
                {
                    Console.WriteLine($"Invalid number of days!");
                }
                else
                {
                    double distance = distanceFromEarth * 2;
                    double totalDays = distance * 226 + days;

                    Console.WriteLine($"Distance: {distance:f2}");
                    Console.WriteLine($"Total number of days: {totalDays:f2}");

                }
            }

        }
    }
}
