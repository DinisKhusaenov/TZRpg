using System.Threading.Tasks;
using Domain.SaveLoad;
using UnityEngine;

namespace Data
{
    public class LocalExpressionRepository : IExpressionRepository
    {
        private const string Key = "LastExpression";
        
        public Task<string> LoadLastExpressionAsync()
        {
            var has = PlayerPrefs.HasKey(Key);
            return Task.FromResult(has ? PlayerPrefs.GetString(Key) : null);
        }

        public Task SaveLastExpressionAsync(string expression)
        {
            PlayerPrefs.SetString(Key, expression ?? string.Empty);
            PlayerPrefs.Save();
            return Task.CompletedTask;
        }
    }
}