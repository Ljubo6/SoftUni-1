using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNums = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int leftSum = 0;
            int rightSum = 0;
            int currentIndex = 0;
            bool isEqual = false;

            for (int index = 0; index < arrayOfNums.Length; index++)
            {
                for (int a = 0; a < index; a++)
                {
                    leftSum = leftSum + arrayOfNums[a];
                }

                for (int b = arrayOfNums.Length - 1; b > index; b--)
                {
                    rightSum = rightSum + arrayOfNums[b];
                }

                if (leftSum == rightSum)
                {
                    currentIndex = index;
                    isEqual = true;
                    break;
                    
                }
                else
                {
                    leftSum = 0;
                    rightSum = 0;
                }
            }
            if (isEqual)
            {
                Console.WriteLine(currentIndex);
            }
            else
            {
                Console.WriteLine("no");
            }
            
        }
    }
}
