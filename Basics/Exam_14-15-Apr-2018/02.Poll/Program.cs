using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Poll
{
    class Program
    {
        static void Main(string[] args)
        {
            int participants = int.Parse(Console.ReadLine());
            int votersFirstPlace = int.Parse(Console.ReadLine());
            double votersSecondPlace = Math.Round(votersFirstPlace * 0.8);
            double votersThirdPlace = Math.Round(votersSecondPlace * 0.9);

            double diff = Math.Abs(participants / 2 - votersFirstPlace - votersSecondPlace - votersThirdPlace);

            if (votersFirstPlace + votersSecondPlace + votersThirdPlace >= participants / 2)
            {
                Console.WriteLine($"First three languages have {diff} votes more");
            }
            else
            {
                Console.WriteLine($"First three languages have {diff} votes less of half votes");
            }

        }
    }
}
