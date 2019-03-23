namespace _03.BarracksWars.Core.Commands
{
    using _03BarracksFactory.Contracts;
    using _03BarracksWars.Attributes;

    public class Retire : Command
    {
        [Inject]
        private IRepository repository;

        public Retire(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];
            this.repository.RemoveUnit(unitType);
            return $"{unitType} retired!";
        }
    }
}
