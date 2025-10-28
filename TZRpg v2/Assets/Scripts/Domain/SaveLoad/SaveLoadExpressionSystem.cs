using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Domain.SaveLoad
{
    public class SaveLoadExpressionSystem
    {
        private readonly IExpressionRepository _expressionRepository;

        public SaveLoadExpressionSystem(IExpressionRepository expressionRepository)
        {
            _expressionRepository = expressionRepository;
        }

        [ItemCanBeNull]
        public Task<string> LoadAsync()
        {
            return _expressionRepository.LoadLastExpressionAsync();
        }

        public Task SaveAsync(string expression)
        {
            return _expressionRepository.SaveLastExpressionAsync(expression ?? string.Empty);
        }
    }
}