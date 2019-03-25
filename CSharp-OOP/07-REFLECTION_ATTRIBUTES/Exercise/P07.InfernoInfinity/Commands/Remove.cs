using P07.InfernoInfinity.Attributes;
using P07.InfernoInfinity.Contracts;
using System.Linq;

namespace P07.InfernoInfinity.Commands
{
    public class Remove : Command
    {
        [Inject]
        private IRepository repository;

        public Remove(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            string weaponName = this.Data[1];
            var weapon = this.repository.Weapons.FirstOrDefault(x => x.Name == weaponName);
            int socketIndex = int.Parse(this.Data[2]);
            this.repository.RemoveGemFromWeapon(weapon, socketIndex);
        }
    }
}
