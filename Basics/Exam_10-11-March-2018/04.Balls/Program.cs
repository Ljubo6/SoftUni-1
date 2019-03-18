using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalPoints = 0;
            int redCounter = 0;
            int orangeCounter = 0;
            int yellowCounter = 0;
            int whiteCounter = 0;
            int blackCounter = 0;
            int otherCounter = 0;

            for (int i = 0; i < n; i++)
            {
                string colour = Console.ReadLine();
                if (colour == "red")
                {
                    totalPoints = totalPoints + 5;
                    redCounter++;
                }
                else if (colour == "orange")
                {
                    totalPoints = totalPoints + 10;
                    orangeCounter++;
                }
                else if (colour == "yellow")
                {
                    totalPoints = totalPoints + 15;
                    yellowCounter++;
                }
                else if (colour == "white")
                {
                    totalPoints = totalPoints + 20;
                    whiteCounter++;
                }
                else if (colour == "black")
                {
                    totalPoints = totalPoints/2;
                    blackCounter++;
                }
                else
                {
                    otherCounter++;
                    continue;
                }
            }
            Console.WriteLine($"Total points: {totalPoints}");
            Console.WriteLine($"Points from red balls: {redCounter}");
            Console.WriteLine($"Points from orange balls: {orangeCounter}");
            Console.WriteLine($"Points from yellow balls: {yellowCounter}");
            Console.WriteLine($"Points from white balls: {whiteCounter}");
            Console.WriteLine($"Other colors picked: {otherCounter}");
            Console.WriteLine($"Divides from black balls: {blackCounter}");

        }
    }
}
