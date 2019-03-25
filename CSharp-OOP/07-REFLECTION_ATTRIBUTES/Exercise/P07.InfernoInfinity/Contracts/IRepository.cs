using System.Collections.Generic;

namespace P07.InfernoInfinity.Contracts
{
    public interface IRepository
    {
        ICollection<IWeapon> Weapons { get; }
        void AddWeapon(IWeapon weapon);
        void AddGemToWeapon(IWeapon weapon, int socketIndex, IGem gem);
        void RemoveGemFromWeapon(IWeapon weapon, int socketIndex);
        void Print(string weaponName);
    }
}
