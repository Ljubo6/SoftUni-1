using System.Collections;
using System.Collections.Generic;

namespace P04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] lake;

        public Lake(int[] stones)
        {
            this.lake = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < lake.Length; i++)
            {
                if (i % 2 == 0)
                {
                    yield return lake[i];
                }
            }

            for (int i = lake.Length - 1; i >= 0; i--)
            {
                if (i % 2 == 1)
                {
                    yield return lake[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
