using P07.InfernoInfinity.Contracts;
using P07.InfernoInfinity.Enums;
using System;
using System.Linq;
using System.Reflection;

namespace P07.InfernoInfinity.Core.Factories
{
    class WeaponFactory : IWeaponFactory
    {
        public IWeapon Create(string[] data)
        {
            string[] weaponInfo = data[1].Split();
            RarityLevel rarityLevel = Enum.Parse<RarityLevel>(weaponInfo[0]);
            var weaponType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == weaponInfo[1]);
            string weaponName = data[2];

            var instance = (IWeapon)Activator.CreateInstance(weaponType, new object[] { rarityLevel, weaponName });
            return instance;
        }
    }
}
