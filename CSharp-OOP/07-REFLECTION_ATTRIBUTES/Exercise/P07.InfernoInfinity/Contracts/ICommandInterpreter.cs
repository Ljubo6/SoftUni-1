namespace P07.InfernoInfinity.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpreteData(string name, string[] data);
    }
}
