using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalFood = int.Parse(Console.ReadLine()) * 1000;
            int totalEaten = 0;
            int gramsOfFood = 0;
            
            while (true)
            {
                
                string command = Console.ReadLine();

                if (command == "Adopted")
                {
                    if (totalFood >= totalEaten)
                    {
                        Console.WriteLine($"Food is enough! Leftovers: {totalFood} grams.");
                        break;
                    }
                    else if (totalFood < totalEaten)
                    {
                        totalFood = Math.Abs(totalFood);
                        Console.WriteLine($"Food is not enough. You need {totalFood} grams more.");
                        break;
                    }

                    
                }

                else
                {

                    bool isInt = int.TryParse(command, out gramsOfFood);

                    if (isInt)
                    {
                        totalFood = totalFood - gramsOfFood;
                        continue;
                    }
                }
               
            }
        }
    }
}
