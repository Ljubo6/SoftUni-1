using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SpaceShip
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double avg = double.Parse(Console.ReadLine());

            double cabinVolume = 2 * 2 * (avg + 0.4);
            double spaceshipVolume = width * length * height;
            int count = (int)(spaceshipVolume / cabinVolume);

            if (count >= 3 && count <= 10)
            {
                Console.WriteLine($"The spacecraft holds {count} astronauts.");
            }
            else if (count < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else
            {
                Console.WriteLine("The spacecraft is too big.");
            }

        }
    }
}
