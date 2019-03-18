using System;
using System.Collections.Generic;
using System.Text;

namespace P05.Mordor.Foods
{
    public class Mushrooms : Food
    {
        private const int points = -10;

        public Mushrooms() : base(points)
        {
        }
    }
}
