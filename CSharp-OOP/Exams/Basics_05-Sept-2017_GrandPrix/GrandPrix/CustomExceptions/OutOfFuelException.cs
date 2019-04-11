using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandPrix.CustomExceptions
{
    public class OutOfFuelException : Exception
    {
        public OutOfFuelException(string message) : base(message)
        {
        }
    }
}
