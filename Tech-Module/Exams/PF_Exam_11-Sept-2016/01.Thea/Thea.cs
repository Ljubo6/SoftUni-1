using System;
using System.Numerics;

namespace _01.Thea
{
    class Thea
    {
        static void Main(string[] args)
        {
            BigInteger photosTaken = BigInteger.Parse(Console.ReadLine());
            int filteringPerImage = int.Parse(Console.ReadLine()); //seconds
            int filterFactor = int.Parse(Console.ReadLine());      // percents
            int uploadingPerImage = int.Parse(Console.ReadLine()); //seconds

            double filteredPhotos = (double)photosTaken * (filterFactor / 100.0);

            BigInteger totalTimeInSeconds = photosTaken * filteringPerImage + (BigInteger)Math.Ceiling(filteredPhotos) * uploadingPerImage;

            int ss = (int)(totalTimeInSeconds % 60);
            totalTimeInSeconds /= 60;
            int mm = (int)(totalTimeInSeconds % 60);
            totalTimeInSeconds /= 60;
            int HH = (int)(totalTimeInSeconds % 24);
            int d = (int)(totalTimeInSeconds / 24);
            Console.WriteLine($"{d}:{HH:d2}:{mm:d2}:{ss:d2}");
        }
    }
}
