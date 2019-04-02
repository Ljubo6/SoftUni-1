using P02.ExtendedDatabase.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ExtendedDatabase.Data
{
    public class Database : IDatabase
    {
        private Dictionary<long, IPerson> byId; // allows quick search
        private Dictionary<string, IPerson> byUsername; // allows quick search
        private IPerson[] people;

        private const int DefaultInitialSize = 16;
        private int currentIndex = 0;

        public Database(params IPerson[] users)
        {
            this.byId = new Dictionary<long, IPerson>();
            this.byUsername = new Dictionary<string, IPerson>();
            this.people = new IPerson[DefaultInitialSize];

            if (users.Length == 0)
            {
                throw new InvalidOperationException("At least one user should be entered into DB upon its initialisation.");
            }

            for (int i = 0; i < users.Length; i++)
            {
                this.Add(users[i]);
            }
        }

        public void Add(IPerson user)
        {
            if (currentIndex >= DefaultInitialSize)
            {
                throw new InvalidOperationException("Database is full.");
            }

            if (this.byId.ContainsKey(user.Id) || this.byUsername.ContainsKey(user.Username))
            {
                throw new InvalidOperationException("User with the same id/username is already registered!");
            }

            this.byId.Add(user.Id, user);
            this.byUsername.Add(user.Username, user);
            this.people[currentIndex++] = user;
        }

        public void Remove()
        {
            if(currentIndex == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            IPerson user = this.people[--currentIndex];
            this.byId.Remove(user.Id);
            this.byUsername.Remove(user.Username);
            this.people[currentIndex] = default(IPerson);
        }

        public IPerson FindById(long id) // O(1)
        {
            if(id < 0)
            {
                throw new ArgumentOutOfRangeException("No user with negative ID found!");
            }

            if (!this.byId.ContainsKey(id))
            {
                throw new InvalidOperationException("No user with the specified ID found!");
            }

            return this.byId[id];
        }

        public IPerson FindByUsername(string username) // O(1)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username provided is null!");
            }

            if (!this.byUsername.ContainsKey(username))
            {
                throw new InvalidOperationException("No user with the specified username found!");
            }

            return this.byUsername[username];
        }

        public IPerson[] Fetch()
        {
            IPerson[] arrayToReturn = new IPerson[this.currentIndex];
            for (int i = 0; i < this.currentIndex; i++)
            {
                arrayToReturn[i] = this.people[i];
            }

            return arrayToReturn;
        }
    }
}
