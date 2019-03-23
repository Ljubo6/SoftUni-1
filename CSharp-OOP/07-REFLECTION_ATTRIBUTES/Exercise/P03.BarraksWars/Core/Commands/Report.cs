namespace _03.BarracksWars.Core.Commands
{
    using _03BarracksFactory.Contracts;
    using _03BarracksWars.Attributes;

    public class Report : Command
    {
        [Inject]
        private IRepository repository;

        public Report(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}
