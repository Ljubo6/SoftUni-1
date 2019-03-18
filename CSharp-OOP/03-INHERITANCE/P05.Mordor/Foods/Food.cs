using System;
using System.Collections.Generic;
using System.Text;

namespace P05.Mordor.Foods
{
    public abstract class Food
    {
        public Food (int points)
        {
            this.Points = points;
        }

        public int Points { get; }
    }
}
