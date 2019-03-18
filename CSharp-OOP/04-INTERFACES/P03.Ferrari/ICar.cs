using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Ferrari
{
    public interface ICar
    {
        string Make { get; }
        string Model { get; }
        string Brakes();
        string GasPedal();
        string Driver { get; }
    }
}
