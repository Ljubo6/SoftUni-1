using P07.InfernoInfinity.Contracts;
using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        private const int socketsCount = 2;

        public Knife(RarityLevel rarityLevel, string name) : base(rarityLevel, name)
        {
            this.Sockets = new IGem[socketsCount];
        }

        protected override int DefaultMinDamage => 3;
        protected override int DefaultMaxDamage => 4;
    }
}
