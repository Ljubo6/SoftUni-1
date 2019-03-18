using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCables
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalLenght = 0;
            int joins = 0;

            for (int i = 0; i < n; i++)
            {
                int lenght = int.Parse(Console.ReadLine());
                string measure = Console.ReadLine();
                if (measure == "meters")
                {
                    lenght = lenght * 100;
                }
                if (lenght >= 20)
                {
                    totalLenght += lenght;
                    joins++;
                }
            }

            totalLenght = totalLenght - (3 * (joins - 1));
            int NumberOfCables = totalLenght / 504;
            int CableRemaining = totalLenght % 504;

            Console.WriteLine(NumberOfCables);
            Console.WriteLine(CableRemaining);
        }
    }
}
