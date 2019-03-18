using System;

namespace _09
{
    class Program
    {
        static void Main(string[] args)
        {
            long pokePower = long.Parse(Console.ReadLine());
            decimal pokePowerOriginal = pokePower;
            long distance = long.Parse(Console.ReadLine());
            byte exhaustionFactor = byte.Parse(Console.ReadLine());
            int targets = 0;

            while (pokePower >= distance)
            {
                pokePower -= distance;
                targets++;

                if (pokePower == pokePowerOriginal / 2.0m)
                {
                    if (exhaustionFactor > 0)
                    {
                        pokePower /= exhaustionFactor;
                    }
                   
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(targets);

        }
    }
}
