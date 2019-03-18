using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int catsNumber = int.Parse(Console.ReadLine());

            int fn = 0;
            int ln = 0;

            for (int i = 1; i <= catsNumber; i++)
            {
                string firstName = Console.ReadLine();
                string lastName = Console.ReadLine();
                int year = int.Parse(Console.ReadLine());
                string letterFn = firstName.Substring(0, 1);


                foreach (char c in letterFn)
                {
                    fn = ((int)c);
                }
                string letterLn = lastName.Substring(0, 1);
                foreach (char d in letterLn)
                {
                    ln = ((int)d);
                }
               
                    Console.WriteLine(year + "" + fn + "" + ln + "" + i);
               
                
            }
        }


    }
}
