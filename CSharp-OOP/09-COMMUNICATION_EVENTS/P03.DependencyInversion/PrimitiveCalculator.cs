namespace P03.DependencyInversion
{
    public class PrimitiveCalculator
    {
        private string strategy;
        private AdditionStrategy additionStrategy;
        private SubtractionStrategy subtractionStrategy;
        private MultiplicationStrategy multiplicationStrategy;
        private DivisionStrategy divisionStrategy;

        public PrimitiveCalculator()
        {
            this.additionStrategy = new AdditionStrategy();
            this.subtractionStrategy = new SubtractionStrategy();
            this.multiplicationStrategy = new MultiplicationStrategy();
            this.divisionStrategy = new DivisionStrategy();
            this.strategy = "Addition";
        }

        public void ChangeStrategy(char @operator)
        {
            switch (@operator)
            {
                case '+':
                    this.strategy = "Addition";
                    break;
                case '-':
                    this.strategy = "Substraction";
                    break;
                case '*':
                    this.strategy = "Multiplication";
                    break;
                case '/':
                    this.strategy = "Division";
                    break;
                default:
                    break;
            }
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            switch (this.strategy)
            {
                case "Addition":
                    return additionStrategy.Calculate(firstOperand, secondOperand);
                case "Substraction":
                    return subtractionStrategy.Calculate(firstOperand, secondOperand);
                case "Multiplication":
                    return multiplicationStrategy.Calculate(firstOperand, secondOperand);
                case "Division":
                    return divisionStrategy.Calculate(firstOperand, secondOperand);
                default:
                    return 0;
            }
        }
    }
}
