using System;
using System.Linq;

namespace _13Jun2016_P02.JediGalaxy
{
    public class JediGalaxy
    {
        public static void Main()
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] galaxy = new int[sizes[0], sizes[1]];
            FillGalaxy(galaxy);

            long ivoPoints = 0;

            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                int[] ivoPosition = command.Split().Select(int.Parse).ToArray();
                int[] evilPosition = Console.ReadLine().Split().Select(int.Parse).ToArray();

                EvilDestroysStars(galaxy, evilPosition);
                ivoPoints += IvoCollectsPoints(galaxy, ivoPosition);

                command = Console.ReadLine();
            }

            Console.WriteLine(ivoPoints);
        }

        private static long IvoCollectsPoints(int[,] galaxy, int[] ivoPosition)
        {
            int row = ivoPosition[0];
            int col = ivoPosition[1];

            long ivoPoints = 0;

            while (row >= 0 && col < galaxy.GetLength(1))
            {
                if (IsCellInsideGalaxy(galaxy, row, col))
                {
                    ivoPoints += galaxy[row, col];
                }

                row--;
                col++;
            }

            return ivoPoints;
        }

        private static void EvilDestroysStars(int[,] galaxy, int[] evilPosition)
        {
            int row = evilPosition[0];
            int col = evilPosition[1];

            while (row >= 0 && col >= 0)
            {
                if (IsCellInsideGalaxy(galaxy, row, col))
                {
                    galaxy[row, col] = 0;
                }

                row--;
                col--;
            }
        }

        public static bool IsCellInsideGalaxy(int[,] galaxy, int row, int col)
        {
            return row >= 0 && row < galaxy.GetLength(0) &&
                   col >= 0 && col < galaxy.GetLength(1);
        }

        public static void FillGalaxy(int[,] galaxy)
        {
            for (int row = 0; row < galaxy.GetLength(0); row++)
            {
                for (int col = 0; col < galaxy.GetLength(1); col++)
                {
                    galaxy[row, col] = row * galaxy.GetLength(1) + col;
                }
            }
        }
    }
}
