using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_Price
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            string travelling = Console.ReadLine();

            if (distance < 1 || distance > 5000) { Console.WriteLine("Invalid number"); }
            else
            {
                if (distance < 20)
                {
                    double taxiPrice = 0.00;
                    if (travelling == "day") { taxiPrice = 0.70 + distance * 0.79; }
                    else if (travelling == "night") {taxiPrice = 0.70 + distance * 0.90; }
                    Console.WriteLine(taxiPrice);
                }

                if (distance >= 20 && distance <100)
                {
                    double busPrice = distance * 0.09;
                    Console.WriteLine(busPrice);
                }
                if (distance >= 100)
                {
                    double trainPrice = distance * 0.06;
                    Console.WriteLine(trainPrice);
                }
               
            }
        }
    }
}
