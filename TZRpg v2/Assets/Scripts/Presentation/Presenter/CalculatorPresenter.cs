using System.Threading.Tasks;
using Domain;
using Domain.SaveLoad;
using Presentation.View;

namespace Presentation.Presenter
{
    public class CalculatorPresenter : ICalculatorPresenter
    {
        private readonly SumCalculator _sumCalculator;
        private readonly SaveLoadExpressionSystem _saveLoadSystem;
        private readonly ICalculatorView _view;

        public CalculatorPresenter(SumCalculator sumCalculator, SaveLoadExpressionSystem saveLoadSystem, ICalculatorView view)
        {
            _sumCalculator = sumCalculator;
            _saveLoadSystem = saveLoadSystem;
            _view = view;
        }

        public async Task InitializeAsync()
        {
            var saved = await _saveLoadSystem.LoadAsync();
            if (!string.IsNullOrEmpty(saved))
                _view.Set(saved);

            _view.OnInputChanged += InputChanged;
            _view.OnResultClicked += ResultClicked;
        }
        
        public void Dispose()
        {
            _view.OnInputChanged -= InputChanged;
            _view.OnResultClicked -= ResultClicked;
        }

        private void ResultClicked()
        {
            _sumCalculator.Calculate(_view.InputText, out var result);
            _view.Set(result);
            _saveLoadSystem.SaveAsync(result);
        }

        private async void InputChanged(string text)
        {
            await _saveLoadSystem.SaveAsync(text);
        }
    }
}