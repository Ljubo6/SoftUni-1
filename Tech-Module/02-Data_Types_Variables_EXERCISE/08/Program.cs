using System;

namespace _08
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());
            
            double[] result = new double[4];

            for (int i = 0; i < numberOfSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                double snowballValue = Math.Pow((snowballSnow / snowballTime), snowballQuality);
                double highestValue = double.MinValue;

                if (snowballValue > highestValue)
                {
                    result[0] = snowballSnow;
                    result[1] = snowballTime;
                    result[2] = snowballValue;
                    result[3] = snowballQuality;
                    highestValue = snowballValue;
                }
            }

            Console.WriteLine($"{result[0]} : {result[1]} = {result[2]} ({result[3]})");


        }
    }
}
