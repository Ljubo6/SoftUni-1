using P07.InfernoInfinity.Enums;

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
