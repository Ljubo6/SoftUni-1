using P07.InfernoInfinity.Attributes;
using P07.InfernoInfinity.Contracts;

namespace P07.InfernoInfinity.Commands
{
    public class Create : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IWeaponFactory weaponFactory;

        public Create(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            var newWeapon = weaponFactory.Create(this.Data);
            repository.AddWeapon(newWeapon);
        }
    }
}
