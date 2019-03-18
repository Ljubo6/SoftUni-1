using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var allRectangles = new List<Rectangle>();

        int[] counts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int rectangleCoun = counts[0];
        int intersectionChecksCount = counts[1];

        for (int i = 0; i < rectangleCoun; i++)
        {
            string[] input = Console.ReadLine().Split();
            if (input.Length >= 5)
            {
                string id = input[0];
                int width = int.Parse(input[1]);
                int height = int.Parse(input[2]);
                int coordinateX = int.Parse(input[3]);
                int coordinateY = int.Parse(input[4]);
                Point topLeftCorner = new Point(coordinateX, coordinateY);

                var currentRectangle = new Rectangle(id, width, height, topLeftCorner);
                allRectangles.Add(currentRectangle);
            }
            else
            {
                return;
            }
            
        }

        for (int i = 0; i < intersectionChecksCount; i++)
        {
            string[] rectanglesIDs = Console.ReadLine().Split();

            var rectOne = allRectangles.FirstOrDefault(r => r.Id == rectanglesIDs[0]);
            var rectTwo = allRectangles.FirstOrDefault(r => r.Id == rectanglesIDs[1]);

            if (rectOne.DoIntersect(rectTwo))
            {
                Console.WriteLine("true"); 
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
