using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Excel
{
    public class Program
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string[][] table = new string[size][];

            for (int row = 0; row < size; row++)
            {
                string[] inputLine = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                table[row] = inputLine;
            }

            string[] command = Console.ReadLine().Split();

            switch (command[0].ToLower())
            {
                case "hide":
                    string header = command[1];
                    int headerIndex = GetHeaderIndex(table, header);
                    PrintHiddenMatrix(table, headerIndex);
                    return;

                case "sort":
                    string sortBy = command[1];
                    int sortByIndex = GetHeaderIndex(table, sortBy);
                    PrintSortedMatrix(table, sortByIndex);
                    return;

                case "filter":
                    string filterBy = command[1];
                    string value = command[2];
                    
                    int filterIndex = GetHeaderIndex(table, filterBy);
                    PrintFilteredMatrix(table, filterIndex, value);
                    return;
                default:
                    break;
            }
        }

        public static void PrintHiddenMatrix(string[][] matrix, int headerIndex)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" | ", matrix[row].Where((x, i) => i != headerIndex).ToArray()));
            }
        }

        public static void PrintSortedMatrix(string[][] matrix, int sortByIndex)
        {
            var newMatrix = matrix.Skip(1).OrderBy(x => x[sortByIndex]).ToArray();

            Console.WriteLine(string.Join(" | ", matrix[0]));
            for (int row = 0; row < newMatrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" | ", newMatrix[row]));
            }
        }

        public static void PrintFilteredMatrix(string[][] matrix, int filterBy, string value)
        {
            var filteredMatrix = matrix.Skip(1).Where(x => x[filterBy] == value).ToArray();

            Console.WriteLine(string.Join(" | ", matrix[0]));
            for (int row = 0; row < filteredMatrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" | ", filteredMatrix[row]));
            }
        }

        public static int GetHeaderIndex(string[][] matrix, string header)
        {
            return Array.IndexOf(matrix[0], header);
        }
    }
}
