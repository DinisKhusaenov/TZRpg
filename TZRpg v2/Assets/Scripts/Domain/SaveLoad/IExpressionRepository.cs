using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Domain.SaveLoad
{
    public interface IExpressionRepository
    {
        [ItemCanBeNull] Task<string> LoadLastExpressionAsync();
        Task SaveLastExpressionAsync(string expression);
    }
}