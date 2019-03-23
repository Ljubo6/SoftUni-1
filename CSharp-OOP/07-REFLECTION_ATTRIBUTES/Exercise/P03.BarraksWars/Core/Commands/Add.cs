namespace _03.BarracksWars.Core.Commands
{
    using _03BarracksWars.Attributes;
    using _03BarracksFactory.Contracts;

    public class Add : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        public Add(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}