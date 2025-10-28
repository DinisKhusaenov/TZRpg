using System.Numerics;
using Domain.Services;

namespace Domain
{
    public class SumCalculator
    {
        private const string ErrorResult = "Error";
        
        private readonly IExpressionValidator _validator;
        private readonly IExpressionParser _parser;

        public SumCalculator(IExpressionValidator validator, IExpressionParser parser)
        {
            _validator = validator;
            _parser = parser;
        }

        public void Calculate(string input, out string result)
        {
            if (!_validator.TryValidate(input))
            {
                result = ErrorResult;
                return;
            }
            if (!_parser.TryParse(input, out var operands) || operands.Count < 1)
            {
                result = ErrorResult;
                return;
            }

            BigInteger sum = 0;
            foreach (BigInteger operand in operands)
                sum += operand;

            result = sum.ToString();
        }
    }
}