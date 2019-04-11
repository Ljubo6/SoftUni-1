namespace P03.DependencyInversion.Strategies
{
    public interface IStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}
