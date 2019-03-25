using P07.InfernoInfinity.Contracts;
using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        private const int socketsCount = 2;
        private const int defaultMinDamage = 3;
        private const int defaultMaxDamage = 4;

        public Knife(RarityLevel rarityLevel, string name) 
            : base(rarityLevel, name, defaultMinDamage, defaultMaxDamage)
        {
            this.Sockets = new IGem[socketsCount];
        }
    }
}
