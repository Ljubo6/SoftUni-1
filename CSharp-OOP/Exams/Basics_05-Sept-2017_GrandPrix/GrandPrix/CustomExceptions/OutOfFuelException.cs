using System;

public class OutOfFuelException : Exception
{
    public OutOfFuelException(string message) : base(message)
    {
    }
}
