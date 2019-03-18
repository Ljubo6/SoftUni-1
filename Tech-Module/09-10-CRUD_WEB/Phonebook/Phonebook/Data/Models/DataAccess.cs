using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Data.Models
{
    public class DataAccess
    {
        public static List<Contact> Phonebook { get; set; } = new List<Contact>();
    }
}
