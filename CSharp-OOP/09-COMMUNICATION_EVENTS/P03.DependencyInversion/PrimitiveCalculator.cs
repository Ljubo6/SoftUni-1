namespace P03.DependencyInversion
{
    using P03.DependencyInversion.Strategies;

    public class PrimitiveCalculator
    {
        private IStrategy strategy;
        private AdditionStrategy additionStrategy;
        private SubtractionStrategy subtractionStrategy;
        private MultiplicationStrategy multiplicationStrategy;
        private DivisionStrategy divisionStrategy;

        public PrimitiveCalculator()
        {
            this.strategy = new AdditionStrategy();
        }

        public void ChangeStrategy(char @operator)
        {
            switch (@operator)
            {
                case '+':
                    this.strategy = new AdditionStrategy();
                    break;
                case '-':
                    this.strategy = new SubtractionStrategy();
                    break;
                case '*':
                    this.strategy = new MultiplicationStrategy();
                    break;
                case '/':
                    this.strategy = new DivisionStrategy();
                    break;
                default:
                    break;
            }
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
