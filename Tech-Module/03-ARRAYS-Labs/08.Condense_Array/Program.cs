using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Condense_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] resultSet = new int[arr.Length - 1];


            while (true)
            {
                if (arr.Length > 1)
                {
                    for (int i = 0; i <= arr.Length - 2; i++)
                    {
                        resultSet[i] = arr[i] + arr[i + 1];
                    }

                    arr = resultSet;

                    if (resultSet.Length == 1)
                    {
                        Console.WriteLine(resultSet[0]);
                        break;
                    }
                    else
                    {
                        Array.Resize(ref resultSet, arr.Length - 1);
                    }
                }
                else
                {
                    Console.WriteLine(arr[0]);
                    break;
                }
                
            }

            
        }
    }
}
