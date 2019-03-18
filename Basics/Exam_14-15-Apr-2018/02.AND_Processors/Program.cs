using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AND_Processors
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int produced = (workers * days * 8) / 3;
            double diff = Math.Abs((count - produced) * 110.1);

            if (produced >= count)
            {
                Console.WriteLine($"Profit: -> {diff:f2} BGN");
            }
            else
            {
                Console.WriteLine($"Loses: -> {diff:f2} BGN");
            }
        }
    }
}
