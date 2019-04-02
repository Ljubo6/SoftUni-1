using P02.ExtendedDatabase.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ExtendedDatabase.Models
{
    public class Person : IPerson
    {
        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public long Id { get; private set; }

        public string Username { get; private set; }
    }
}
