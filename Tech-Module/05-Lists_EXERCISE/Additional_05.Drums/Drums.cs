using System;
using System.Collections.Generic;
using System.Linq;

namespace Additional_05.Drums
{
    class Drums
    {
        static void Main(string[] args)
        {
            decimal savings = decimal.Parse(Console.ReadLine());

            List<int> drumSetInitial = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> drumSet = new List<int>(drumSetInitial);

            string command = Console.ReadLine();

            while (command != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(command);

                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= hitPower;

                    if (drumSet[i] <= 0)
                    {
                        if (savings >= drumSetInitial[i] * 3)
                        {
                            drumSet[i] = drumSetInitial[i];
                            savings -= drumSetInitial[i] * 3;
                        }
                        else
                        {
                            drumSet.RemoveAt(i);
                            drumSetInitial.RemoveAt(i);
                            i--;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', drumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
