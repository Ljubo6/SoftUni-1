using P07.InfernoInfinity.Contracts;

namespace P07.InfernoInfinity.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        

        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data
        {
            get => this.data;
            private set => this.data = value;
        }

        public abstract void Execute();
    }
}
