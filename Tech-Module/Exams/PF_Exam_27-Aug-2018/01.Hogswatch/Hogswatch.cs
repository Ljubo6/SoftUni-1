using System;

namespace _01.Hogswatch
{
    class Hogswatch
    {
        static void Main(string[] args)
        {
            int homesToVisit = int.Parse(Console.ReadLine());
            int presents = int.Parse(Console.ReadLine());

            int presentsInitial = presents;
            int homesVisited = 0;
            int timesBack = 0;
            int totalPresentsTaken = 0;
            bool hasToGoBack = false;
            int presentsDue = 0;

            while (homesToVisit - homesVisited > 0)
            {
                for (int i = 0; i < homesToVisit; i++)
                {
                    if (hasToGoBack == true)
                    {
                        presents -= presentsDue;
                        hasToGoBack = false;
                    }

                    int childrenPerHouse = int.Parse(Console.ReadLine());
                    homesVisited++;

                    if (presents >= childrenPerHouse)
                    {
                        presents -= childrenPerHouse;
                        continue;
                    }
                    else
                    {
                        presentsDue = childrenPerHouse - presents;
                        presents = (presentsInitial / homesVisited) * (homesToVisit - homesVisited) + presentsDue;
                        timesBack++;
                        hasToGoBack = true;
                        totalPresentsTaken += presents;
                    }
                }

            }    

            if (timesBack == 0)
            {
                Console.WriteLine(presents);
            }
            else
            {
                Console.WriteLine(timesBack);
                Console.WriteLine(totalPresentsTaken);
            }
        }
    }
}
