using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int passangersBegin = int.Parse(Console.ReadLine());
            int busStopsCount = int.Parse(Console.ReadLine());
            int kontrola = 2;
            int passangersFinal = 0;

            for (int i = 1; i <= busStopsCount; i++)
            {
                int passangersOff = int.Parse(Console.ReadLine());
                int passangersOn = int.Parse(Console.ReadLine());
                passangersFinal = passangersBegin - passangersOff + passangersOn;
                if (i % 2 == 0)
                {
                    passangersFinal = passangersFinal - kontrola;
                }
                else
                {
                    passangersFinal = passangersFinal + kontrola;
                }
                passangersBegin = passangersFinal;
            }
            Console.WriteLine($"The final number of passengers is : {passangersFinal}");
        }
    }
}
