using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ExtendedDatabase.Contracts
{
    public interface IPerson
    {
        long Id { get; }
        string Username { get; }
    }
}
