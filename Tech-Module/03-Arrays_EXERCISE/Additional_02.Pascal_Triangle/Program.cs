using System;
using System.Collections.Generic;

namespace Additional_02.Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<int> lastRow = new List<int>();

            for (int i = 0; i < lines; i++)
            {
                lastRow.Add(1);
                List<int> triangle = new List<int>(lastRow);

                if (i > 1)
                {
                    for (int a = 1; a < triangle.Count - 1; a++)
                    {
                        lastRow[a] = triangle[a-1] + triangle[a];
                    }
                }
                Console.WriteLine(string.Join(' ', lastRow));
            }
        }
    }
}
