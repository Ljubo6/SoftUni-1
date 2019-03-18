using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Manipulate_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Arr = Console.ReadLine().Split(' ').ToArray();
            int n = int.Parse(Console.ReadLine());

            for (int a = 1; a <= n; a++)
            {
                string[] command = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Reverse")
                {
                    Array.Reverse(Arr);
                }
                else if (command[0] == "Distinct")
                {
                    Arr = Arr.Distinct().ToArray();
                }
                else if(command[0] == "Replace")
                {
                    bool Parsed = Int32.TryParse (command[1], out int indexReq);
                    if (Parsed == true)
                    {
                        Arr[indexReq] = command[2];
                    }
                    
                }

            }
            for (int i = 0; i < Arr.Length - 1; i++)
            {
                Console.Write(Arr[i] + ", ");
            }
            Console.WriteLine(Arr[Arr.Length - 1]);
        }
    }
}
