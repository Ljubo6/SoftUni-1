using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string breed = Console.ReadLine();
            string sex = Console.ReadLine();
            int lifeExpectancy = 0;

            if (breed == "British Shorthair")
            {
                if (sex == "m")
                {
                    lifeExpectancy = 13;
                }
                else if (sex == "f")
                {
                    lifeExpectancy = 14;
                }
            }
            else if (breed == "Siamese")
            {
                if (sex == "m")
                {
                    lifeExpectancy = 15;
                }
                else if (sex == "f")
                {
                    lifeExpectancy = 16;
                }
            }
            else if (breed == "Persian")
            {
                if (sex == "m")
                {
                    lifeExpectancy = 14;
                }
                else if (sex == "f")
                {
                    lifeExpectancy = 15;
                }
            }
            else if (breed == "Ragdoll")
            {
                if (sex == "m")
                {
                    lifeExpectancy = 16;
                }
                else if (sex == "f")
                {
                    lifeExpectancy = 17;
                }
            }
            else if (breed == "American Shorthair")
            {
                if (sex == "m")
                {
                    lifeExpectancy = 12;
                }
                else if (sex == "f")
                {
                    lifeExpectancy = 13;
                }
            }
            else if (breed == "Siberian")
            {
                if (sex == "m")
                {
                    lifeExpectancy = 11;
                }
                else if (sex == "f")
                {
                    lifeExpectancy = 12;
                }
            }
            else
            {
                Console.WriteLine($"{breed} is invalid cat!");
                return;
            }

            Console.WriteLine(lifeExpectancy * 2 + " cat months");

        }
    }
}
