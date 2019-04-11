using System;

namespace GrandPrix.CustomExceptions
{
    public class BlownTyreException : Exception
    {
        public BlownTyreException(string message) : base(message)
        {
        }
    }
}
