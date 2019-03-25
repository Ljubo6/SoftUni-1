using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        int MinDamage { get; }
        int MaxDamage { get; }
        string Name { get; }
        IGem[] Sockets { get; }
        RarityLevel RarityLevel { get; }
    }
}
