using System;
using System.Collections.Generic;
using System.Linq;

namespace Additional_04.LIS
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] List = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> LIS = new List<int>();

            for (int i = 0; i < List.Length - 1; i++)
            {
                for (int a = i + 1; a < List.Length; a++)
                {
                    if (List[i] < List[a])
                    {
                        LIS.Add(List[a]);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            
            foreach (var item in LIS)
            {
                Console.WriteLine(item);
            }
        }
    }
}
