using P07.InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        int MinDamage { get; }
        int MaxDamage { get; }
        string Name { get; }
        IGem[] Sockets { get; }
        RarityLevel RarityLevel { get; }
        void AddGem(int index, IGem gem);
        void RemoveGem(int index);
    }
}
