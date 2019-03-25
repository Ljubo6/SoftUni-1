using P07.InfernoInfinity.Attributes;
using P07.InfernoInfinity.Contracts;

namespace P07.InfernoInfinity.Commands
{
    public class Print : Command
    {
        [Inject]
        private IRepository repository;

        public Print(string[] data) : base(data)
        {

        }

        public override void Execute()
        {
            string weaponName = this.Data[1];
            this.repository.Print(weaponName);
        }
    }
}
