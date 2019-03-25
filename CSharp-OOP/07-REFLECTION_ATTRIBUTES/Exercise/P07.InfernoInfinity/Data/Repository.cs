using P07.InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.InfernoInfinity.Data
{
    public class Repository : IRepository
    {
        private readonly List<IWeapon> weapons;

        public Repository()
        {
            this.weapons = new List<IWeapon>();
        }

        public ICollection<IWeapon> Weapons => this.weapons;

        public void AddWeapon(IWeapon newWeapon)
        {
            this.weapons.Add(newWeapon);
        }

        public void AddGemToWeapon(IWeapon weapon, int socketIndex, IGem gem)
        {
            if(socketIndex < weapon.Sockets.Length)
            {
                weapon.Sockets[socketIndex] = gem;
            }
        }

        public void RemoveGemFromWeapon(IWeapon weapon, int index)
        {
            if (index < weapon.Sockets.Length)
            {
                weapon.Sockets[index] = null;
            }
        }

        public void Print(string weaponName)
        {
            var weaponToPrint = this.Weapons.FirstOrDefault(x => x.Name == weaponName);
            Console.WriteLine(weaponToPrint);
        }
    }
}
