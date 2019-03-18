using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeLenght = int.Parse(Console.ReadLine());
            int cakeWidth = int.Parse(Console.ReadLine());

            int pieces = cakeLenght * cakeWidth;
            int piecestaken = 0;
            int totalpiecestaken = 0;
            int difference = Math.Abs(cakeLenght * cakeWidth - totalpiecestaken);
            

            while (pieces >= 0)
            {
                string command = Console.ReadLine().ToLower();
                if (command == "stop")
                {
                    break;
                }
                else
                {
                    int.TryParse(command, out piecestaken);
                }

                totalpiecestaken = totalpiecestaken + piecestaken;
                pieces = pieces - piecestaken;
                
                if (pieces < 0)
                {
                    int morepieces = Math.Abs(pieces);
                    Console.WriteLine($"No more cake left! You need {morepieces} pieces more.");
                    break;
                }

            }

            if (pieces >= 0)
            {
                Console.WriteLine($"{pieces} pieces are left.");
            }
           
        }
    }
}
