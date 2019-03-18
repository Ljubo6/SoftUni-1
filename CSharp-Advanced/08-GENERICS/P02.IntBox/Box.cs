using System;
using System.Collections.Generic;
using System.Text;

namespace P02.IntBox
{
    public class Box 
    {
        public static int GetCountOfGreaterElements<T>(List<T> list, T value) where T : IComparable
        {
            int count = 0;
            foreach (var item in list)
            {
                if (item.CompareTo(value) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
