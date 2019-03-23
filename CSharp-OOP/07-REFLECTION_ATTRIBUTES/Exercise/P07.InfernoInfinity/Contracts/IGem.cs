using P07.InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.InfernoInfinity.Contracts
{
    public interface IGem
    {
        int Strenght { get; }
        int Agility { get; }
        int Vitality { get; }
        ClarityLevel ClarityLevel { get; }
    }
}
