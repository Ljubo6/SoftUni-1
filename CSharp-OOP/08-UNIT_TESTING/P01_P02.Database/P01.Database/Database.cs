using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Database
{
    public class Database
    {
        private const int Capacity = 16;
        private int currentIndex = 0;
        private int[] database;

        public Database(params int[] integers)
        {
            this.database = new int[Capacity];

            if(integers.Length == 0)
            {
                throw new InvalidOperationException("At least one element should be entered upon initialisation.");
            }

            for (int i = 0; i < integers.Length; i++)
            {
                this.Add(integers[i]);
            }
        }

        public void Add(int integer)
        {
            if (this.ValidateCurrentIndexOutOfRange())
            {
                throw new InvalidOperationException("Database is full.");
            }

            database[this.currentIndex++] = integer;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Database containts no elements.");
            }

            database[--currentIndex] = default(int);
        }

        public int[] Fetch()
        {
            int[] arrayToReturn = new int[this.currentIndex];
            for (int i = 0; i < this.currentIndex; i++)
            {
                arrayToReturn[i] = database[i];
            }

            return arrayToReturn;
        }

        private bool ValidateCurrentIndexOutOfRange()
        {
            return this.currentIndex >= Capacity;
        }
    }
}
