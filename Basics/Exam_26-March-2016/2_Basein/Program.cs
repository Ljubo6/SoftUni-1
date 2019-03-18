using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_TrubiBasein
{
    class Program
    {
        static void Main(string[] args)
        {
            int poolVolume = int.Parse(Console.ReadLine());
            int pipeOne = int.Parse(Console.ReadLine());
            int pipeTwo = int.Parse(Console.ReadLine());
            double timeAbsent = double.Parse(Console.ReadLine());

            double poolFullness = (pipeOne + pipeTwo) * timeAbsent;

            if (poolFullness <= poolVolume)
            {
                Console.WriteLine("The pool is " + (int)(poolFullness / poolVolume * 100) +
                    "% full. Pipe 1: " + (int)(pipeOne * timeAbsent / poolFullness * 100) + "%. Pipe 2: " +
                    (int)(pipeTwo * timeAbsent / poolFullness * 100) + "%.");
            }
            else if (poolFullness > poolVolume)
            {
                Console.WriteLine($"For {timeAbsent} hours the pool overflows with " + (int)(poolFullness - poolVolume) + " liters.");
            }
        }
    }
}
