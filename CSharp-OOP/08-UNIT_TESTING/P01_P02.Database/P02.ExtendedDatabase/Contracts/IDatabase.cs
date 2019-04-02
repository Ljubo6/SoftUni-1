using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ExtendedDatabase.Contracts
{
    public interface IDatabase
    {
        void Add(IPerson user);
        void Remove();
        IPerson FindByUsername(string username);
        IPerson FindById(long id);
        IPerson[] Fetch();
    }
}
