using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.IntBox
{
    public class StartUp
    {
        public static void Main()
        {
            List<double> list = new List<double>();

            double lines = double.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                double input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            double comparableValue = double.Parse(Console.ReadLine());

            Console.WriteLine(Box.GetCountOfGreaterElements(list, comparableValue));
        }
    }
}
