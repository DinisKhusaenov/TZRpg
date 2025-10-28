using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.View
{
    public class CalculatorView : MonoBehaviour, ICalculatorView
    {
        public event Action OnResultClicked;
        public event Action<string> OnInputChanged;
        
        [SerializeField] private TMP_InputField _input;
        [SerializeField] private Button _result;

        public string InputText => _input.text;

        public void Set(string savedText)
        {
            _input.text = savedText;
        }

        private void OnEnable()
        {
            _result.onClick.AddListener(ResultClicked);
            _input.onValueChanged.AddListener(ValueChanged);
        }

        private void OnDisable()
        {
            _result.onClick.RemoveListener(ResultClicked);
            _input.onValueChanged.RemoveListener(ValueChanged);
        }

        private void ValueChanged(string text)
        {
            OnInputChanged?.Invoke(text);
        }

        private void ResultClicked()
        {
            OnResultClicked?.Invoke();
        }
    }
}