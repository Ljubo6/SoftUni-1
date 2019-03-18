using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FruitDiet
{
    class Program
    {
        static void Main(string[] args)
        {
            int raspberry = int.Parse(Console.ReadLine());
            int strawberry = int.Parse(Console.ReadLine());
            int cherry = int.Parse(Console.ReadLine());
            double juice = double.Parse(Console.ReadLine());

            int raspberryCount = 0; 
            int strawberryCount = 0;  
            int cherryCount = 0; 

            while (juice >= 0)
            {
                cherryCount = (int)(juice / 15);
                
                raspberryCount = (int)(juice / 4.5);

                if (cherryCount >= cherry)
                {
                    cherryCount = cherry;
                    juice = juice - cherryCount * 15; 
                }
                else { juice = juice - cherryCount * 15; }

                if (juice >= 7.5)
                {
                    strawberryCount = (int)(juice / 7.5);
                    if (strawberryCount >= strawberry)
                    {
                        strawberryCount = strawberry;
                        juice = juice - strawberry * 7.5;
                    }
                    else { juice = juice - strawberry * 7.5; }
                }
                
                if (juice >= 4.5)
                {
                    raspberryCount = (int)(juice / 4.5);
                    if (raspberryCount >= raspberry)
                    {
                        raspberryCount = raspberry;
                        juice = juice - strawberry * 4.5;
                    }
                    else { juice = juice - raspberry * 4.5; }
                    
                }
                //else { juice = juice - strawberry * 4.5; break; }
                
            }
            Console.WriteLine($"{cherryCount},{strawberryCount},{raspberryCount}");


        }
    }
}
