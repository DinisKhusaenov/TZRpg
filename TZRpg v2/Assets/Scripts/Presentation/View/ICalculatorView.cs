using System;

namespace Presentation.View
{
    public interface ICalculatorView
    {
        event Action OnResultClicked;
        event Action<string> OnInputChanged;
        string InputText { get; }
        void Set(string savedText);
    }
}