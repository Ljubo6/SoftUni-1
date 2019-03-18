using System;

namespace _08.Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int rows = 1; rows <= n; rows++)
            {
                for (int col = 1; col <= rows; col++)
                {
                    Console.Write(rows + " ");
                    
                }
                Console.WriteLine();
            }
        }
    }
}
