using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Manipulate_Safe
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Arr = Console.ReadLine().Split(' ').ToArray();
           

            while(true)
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
                else if (command[0] == "Replace")
                {
                    bool Parsed = Int32.TryParse(command[1], out int indexReq);
                    if (Parsed == true)
                    {
                        if (indexReq > Arr.Length - 1 || indexReq < 0)
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        else
                        {
                            Arr[indexReq] = command[2];
                        }
                        
                    }
                }
                else if (command[0] == "END")
                {
                    for (int i = 0; i < Arr.Length - 1; i++)
                    {
                        Console.Write(Arr[i] + ", ");
                    }
                    Console.WriteLine(Arr[Arr.Length - 1]);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

            }
            
        }
    }
}
