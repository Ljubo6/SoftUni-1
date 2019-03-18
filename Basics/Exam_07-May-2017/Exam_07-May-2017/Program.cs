using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_07_May_2017
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());
            int specialNumber = int.Parse(Console.ReadLine());
            int ControlNumber = int.Parse(Console.ReadLine());
            bool areEqual = false;

            int workingNumber = numberOne * 100 + numberTwo * 10 + numberThree;

            for (int i = workingNumber; i >= 111; i--)
            {
                if (i % 3 == 0)
                {
                    specialNumber = specialNumber + 5;
                    if (specialNumber >= ControlNumber)
                    {
                        areEqual = true;
                        //return;
                    }
                 break;  
                }
                else if (i % 10 == 5)
                {
                    specialNumber = specialNumber - 2;
                    if (specialNumber >= ControlNumber)
                    {
                        areEqual = true;
                        //return;
                    }
                 break;
                }
                else if (i % 2 == 0)
                {
                    specialNumber = specialNumber * 2;
                    if (specialNumber >= ControlNumber)
                    {
                        areEqual = true;
                        //return;
                    }
                }
                else
                {
                    continue;
                }
               
            }
            if (areEqual == true)
            {
                Console.WriteLine($"Yes! Control number was reached! " +
                            $"Current special number is {specialNumber}.");
            }
            else
            {
                Console.WriteLine("blabla");
            }
            



        }
    }
}
