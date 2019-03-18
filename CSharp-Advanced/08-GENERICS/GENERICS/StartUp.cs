using System;
using System.Collections.Generic;
using System.Linq;

namespace GENERICS
{
    public class StartUp
    {
        public static void Main()
        {
            List<string> list = new List<string>();

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                list.Add(input);
            }

            string comparableValue = Console.ReadLine();

            Console.WriteLine(Box.GetCountOfGreaterElements(list, comparableValue));
           
        }
    }
}
