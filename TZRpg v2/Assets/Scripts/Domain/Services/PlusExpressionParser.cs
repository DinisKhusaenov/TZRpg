using System;
using System.Collections.Generic;
using System.Numerics;

namespace Domain.Services
{
    public class PlusExpressionParser : IExpressionParser
    {
        public bool TryParse(string input, out IReadOnlyList<BigInteger> operands)
        {
            var parts = input.Split('+');
            var values = new BigInteger[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                if (!BigInteger.TryParse(parts[i], out var value))
                {
                    operands = Array.Empty<BigInteger>();
                    return false;
                }

                values[i] = value;
            }

            operands = values;
            return true;
        }
    }
}