using System;

namespace Additional_02.Center_Point
{
    class CenterPoint
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());

            double distance1 = GettingDistanceToCenter(x1, y1);
            double distance2 = GettingDistanceToCenter(x2, y2);
            if (distance1 > distance2)
            {
                Console.WriteLine($"({x2}, {y2})");
            }
            else if (distance1 < distance2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x1}, {y1})");
            }

        }

        private static double GettingDistanceToCenter(int x, int y)
        {
            double distance = Math.Sqrt(x * x + y * y);
            return distance;
        }
    }
}
