using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace CalculatorApp.Models
{
    public class Calculator
    {
        public Calculator()
        {
            this.Result = 0;
        }

        public decimal LeftOperand { get; set; }
        public string Operator { get; set; }
        public decimal RightOperand { get; set; }
        public decimal Result { get; set; }
        public DateTime TimeOfCalculation { get; set; }

        public BigInteger Factorial(BigInteger n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        public void CalculateResult()
        {
            switch (this.Operator)
            {
                case "+":
                    this.Result = this.LeftOperand + this.RightOperand;
                    break;
                case "-":
                    this.Result = this.LeftOperand - this.RightOperand;
                    break;
                case "*":
                    this.Result = this.LeftOperand * this.RightOperand;
                    break;
                case "/":
                    if (this.RightOperand != 0)
                    {
                        this.Result = this.LeftOperand / this.RightOperand;
                    }
                    break;
                case "Permutation":
                    BigInteger permutationResult = Factorial((BigInteger)this.LeftOperand) / Factorial((BigInteger)this.LeftOperand - (BigInteger)this.RightOperand);
                    this.Result = (decimal)permutationResult;
                    break;
                case "Combination":
                    BigInteger combinationResult = Factorial((BigInteger)this.LeftOperand) / (Factorial((BigInteger)this.RightOperand) * Factorial((BigInteger)this.LeftOperand - (BigInteger)this.RightOperand));
                    this.Result = (decimal)combinationResult;
                    break;
                default:
                    break;
            }
        }
    }
}
