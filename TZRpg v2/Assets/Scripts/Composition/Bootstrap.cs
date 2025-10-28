using Data;
using Domain;
using Domain.SaveLoad;
using Domain.Services;
using Presentation.Presenter;
using Presentation.View;
using UnityEngine;

namespace Composition
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CalculatorView _view;

        private ICalculatorPresenter _calculatorPresenter;

        private async void Awake()
        {
            var validator = new ExpressionValidator();
            var parser = new PlusExpressionParser();
            var calculator = new SumCalculator(validator, parser);

            var repository = new LocalExpressionRepository();
            var saveLoad = new SaveLoadExpressionSystem(repository);

            _calculatorPresenter = new CalculatorPresenter(calculator, saveLoad, _view);

            await _calculatorPresenter.InitializeAsync();
        }

        private void OnDestroy()
        {
            _calculatorPresenter.Dispose();
        }
    }
}