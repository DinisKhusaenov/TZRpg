using System.Collections.Generic;
using System.Numerics;

namespace Domain.Services
{
    public interface IExpressionParser
    {
        bool TryParse(string input, out IReadOnlyList<BigInteger> operands);
    }
}