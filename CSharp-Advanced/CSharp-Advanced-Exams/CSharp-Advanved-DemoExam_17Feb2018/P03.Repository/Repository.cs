using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Repository
    {
        private Dictionary<int, Person> people;
        private int curentIndex;

        public Repository()
        {
            this.people = new Dictionary<int, Person>();
            this.curentIndex = 0;
        }

        public void Add(Person person)
        {
            this.people.Add(curentIndex, person);
            curentIndex++;
        }

        public Person Get(int id)
        {
            return this.people[id];
        }

        public bool Update(int id, Person newPerson)
        {
            if (!this.people.ContainsKey(id))
            {
                return false;
            }

            people[id] = newPerson;
            return true;
        }

        public bool Delete(int id)
        {
            if (!this.people.ContainsKey(id))
            {
                return false;
            }

            return this.people.Remove(id);
        }

        public int Count
        {
            get => this.people.Count;
        }
    }
}