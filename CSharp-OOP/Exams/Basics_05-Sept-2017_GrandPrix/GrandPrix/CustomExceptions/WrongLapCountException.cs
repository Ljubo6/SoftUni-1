using System;

public class WrongLapCountException : Exception
{
    public WrongLapCountException(string message) : base(message)
    {
    }
}
