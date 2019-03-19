using System;
using System.Collections.Generic;

namespace Exercise_P06.ConnectedAreaInMatrix
{
    public class Cell
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }

    public class Area : IComparable<Area>
    {
        public Area(Cell startingCell)
        {
            this.StartingCell = startingCell;
            this.Size = 0;
        }

        public Cell StartingCell { get; set; }

        public int Size { get; set; }

        public int CompareTo(Area other)
        {
            var compare = other.Size.CompareTo(this.Size);
            if (compare == 0)
            {
                compare = this.StartingCell.Row.CompareTo(other.StartingCell.Row);
                if (compare == 0)
                {
                    return this.StartingCell.Col.CompareTo(other.StartingCell.Col);
                }
            }

            return compare;
        }
    }

    public class Program
    {
        private static char[,] matrix;
        private static SortedSet<Area> areas = new SortedSet<Area>();
        //x -> cell visited

        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            matrix = new char[rows, cols];
            ReadData(rows, cols);

            var currentCell = FindCell(rows, cols);

            while (currentCell != null)
            {
                var area = new Area(currentCell);
                TraverseArea(currentCell, rows, cols, area);
                areas.Add(area);
                currentCell = FindCell(rows, cols);
            }

            int index = 1;
            Console.WriteLine($"Total areas found: {areas.Count}");
            foreach (var area in areas)
            {
                Console.WriteLine($"Area #{index} at ({area.StartingCell.Row}, {area.StartingCell.Col}), size: {area.Size}");
                index++;
            }
        }

        private static void TraverseArea(Cell currentCell, int rows, int cols, Area area)
        {
            if (matrix[currentCell.Row, currentCell.Col] != '*' && matrix[currentCell.Row, currentCell.Col] != 'x')
            {
                matrix[currentCell.Row, currentCell.Col] = 'x';
                area.Size++;

                if (currentCell.Row - 1 >= 0)
                {
                    TraverseArea(new Cell(currentCell.Row - 1, currentCell.Col), rows, cols, area);
                }

                if (currentCell.Row + 1 < rows)
                {
                    TraverseArea(new Cell(currentCell.Row + 1, currentCell.Col), rows, cols, area);
                }

                if (currentCell.Col - 1 >= 0)
                {
                    TraverseArea(new Cell(currentCell.Row, currentCell.Col - 1), rows, cols, area);
                }

                if (currentCell.Col + 1 < cols)
                {
                    TraverseArea(new Cell(currentCell.Row, currentCell.Col + 1), rows, cols, area);
                }
            }
        }

        private static Cell FindCell(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if(matrix[row, col] != '*' && matrix[row, col] != 'x')
                    {
                        var cell = new Cell(row, col);
                        return cell;
                    }
                }
            }
            return null;
        }

        private static void ReadData(int rows, int cols)
        {
            

            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }
    }
}
