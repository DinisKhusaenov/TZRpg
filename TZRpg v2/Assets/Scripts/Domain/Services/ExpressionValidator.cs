using System.Text.RegularExpressions;

namespace Domain.Services
{
    public class ExpressionValidator : IExpressionValidator
    {
        private static readonly Regex Pattern = new(@"^\d+(?:\+\d+)*$", RegexOptions.Compiled);
        
        public bool TryValidate(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && Pattern.IsMatch(input);
        }
    }
}
