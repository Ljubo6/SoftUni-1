using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LastNumbersSeq
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] seq = new int[int.Parse(Console.ReadLine())];
            seq[0] = 1;
            int k = int.Parse(Console.ReadLine());
            int sum = 0;

            
            for (int i = 1; i <= seq.Length ; i++)
            {
                for (int a = 0; a < k; a++)
                {
                    sum += seq[i];
                }
                seq[i] = sum;
            }


            for (int i = 0; i < seq.Length; i++)
            {
                Console.Write(seq[i] + " ");
            }


        }
    }
}
