using System;
using System.Linq;

namespace _26Feb2016_P02.ParkinSystem
{
    public class StartUp
    {
        public static void Main()
        {
            int[] lotSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int row = lotSize[0];
            int col = lotSize[1];

            bool[,] parkingLot = new bool[row, col];
            //false - free
            //true - busy

            string input = Console.ReadLine();

            while (input != "stop")
            {
                int[] coordinates = input.Split().Select(int.Parse).ToArray();
                int entryRow = coordinates[0];
                int destinationRow = coordinates[1];
                int destinationCol = coordinates[2];

                if (HasRowFreeSpots(parkingLot, destinationRow))
                {
                    if (parkingLot[coordinates[1], coordinates[2]] == false) // spot is free
                    {
                        parkingLot[coordinates[1], coordinates[2]] = true;
                    }
                    else // spot occupied
                    {
                        FindBestSpot(parkingLot, coordinates);
                        parkingLot[coordinates[1], coordinates[2]] = true;
                    }

                    Console.WriteLine(CalculateDistanceToDestinationSpot(parkingLot, entryRow, coordinates));
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    Console.WriteLine($"Row {destinationRow} full");
                }

                input = Console.ReadLine();
            }
        }

        private static int CalculateDistanceToDestinationSpot(bool[,] parkingLot, int entryRow, int[] coordinates)
        {
            return Math.Abs(coordinates[0] - coordinates[1]) + coordinates[2] + 1;
        }

        private static void FindBestSpot(bool[,] parkingLot, int[] coodinates)
        {
            for (int i = 1; i < parkingLot.GetLength(1); i++)
            {
                if (coodinates[2] - i > 0 && parkingLot[coodinates[1], coodinates[2] - i] == false)
                {
                    coodinates[2] -= i;
                    return;
                }
                else if (coodinates[2] + i < parkingLot.GetLength(1) && parkingLot[coodinates[1], coodinates[2] + i] == false)
                {
                    coodinates[2] += i;
                    return;
                }
            }
        }

        private static int CalculateDistanceToDestinationSpot(bool[,] parkingLot, int entryRow, int destinationRow, int destinationCol)
        {
            return Math.Abs(entryRow - destinationRow) + destinationCol + 1;
        }

        private static bool HasRowFreeSpots(bool[,] parkingLot, int destinationRow)
        {
            int freeSpotsCount = 0;
            for (int i = 1; i < parkingLot.GetLength(1); i++)
            {
                if (parkingLot[destinationRow, i] == false)
                {
                    freeSpotsCount++;
                }
            }

            return freeSpotsCount > 0;
        }
    }
}