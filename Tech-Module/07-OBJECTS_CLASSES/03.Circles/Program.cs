using System;
using System.Linq;

namespace _03.Circles
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Circle
    {
        public Point Center { get; set; }
        public int radius { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] dataCircleOne = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] dataCircleTwo = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Point p1 = new Point { X = dataCircleOne[0], Y = dataCircleOne[1] };
            Point p2 = new Point { X = dataCircleTwo[0], Y = dataCircleTwo[1] };

            Circle circleOne = new Circle { Center = p1, radius = dataCircleOne[2] };
            Circle circleTwo = new Circle { Center = p2, radius = dataCircleTwo[2] };

        }

        static bool Intersect(Circle c1, Circle c2)
        {
            
        }
    }
}
