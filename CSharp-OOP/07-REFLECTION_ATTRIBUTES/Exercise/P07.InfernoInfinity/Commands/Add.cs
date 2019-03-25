using P07.InfernoInfinity.Attributes;
using P07.InfernoInfinity.Contracts;
using System.Linq;

namespace P07.InfernoInfinity.Commands
{
    public class Add : Command
    {
        [Inject]
        private IGemFactory gemFactory;
        [Inject]
        private IRepository repository;

        public Add(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            var weaponName = this.Data[1];
            int socketIndex = int.Parse(this.Data[2]);
            var gemData = this.Data[3].Split();

            var weapon = this.repository.Weapons.FirstOrDefault(x => x.Name == weaponName);
            var gem = gemFactory.Create(gemData);

            this.repository.AddGemToWeapon(weapon, socketIndex, gem);
        }
    }
}
