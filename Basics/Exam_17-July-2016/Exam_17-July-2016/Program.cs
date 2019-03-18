using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_17_July_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoinCount = int.Parse(Console.ReadLine());
            double yuanCount = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());
            
            double result = ((bitcoinCount * 1168 + yuanCount * 0.15 * 1.76) / 1.95) * (1.0 - (commission) / 100.00);
            Console.WriteLine($"{result:f2}");
        }
    }
}
