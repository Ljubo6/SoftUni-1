using System;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagonsCount = int.Parse(Console.ReadLine());
            long[] peopleInWagon = new long[wagonsCount];

            for (int i = 0; i < wagonsCount; i++)
            {
                peopleInWagon[i] = long.Parse(Console.ReadLine());
            }

            Console.WriteLine(String.Join(' ', peopleInWagon));
            Console.WriteLine(peopleInWagon.Sum());
        }
    }
}
