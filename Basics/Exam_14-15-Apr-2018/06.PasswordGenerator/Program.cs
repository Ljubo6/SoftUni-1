using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());
            int f = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            int passwordCount = 0;
            string result = "";

            for (int i = 1 ; i <= a; i++)
            {
                for (int j = 'A'; j <= b; j++)
                {
                    for (int k = 'a'; k <= c; k++)
                    {
                        for (int l = 1; l <= d; l++)
                        {
                            for (int m = 1; m <= e; m++)
                            {
                                for (int n = 1; n <= f; n++)
                                {
                                    passwordCount++;
                                    result = i+""+(char)j+""+(char)k+""+l+""+m+""+n;
                                }
                            }
                        }
                    }
                }
            }
            if (N == passwordCount)
            {
                Console.WriteLine($"{result}");
            }
        }
    }
}
