using System;
using System.Threading.Tasks;

namespace Presentation.Presenter
{
    public interface ICalculatorPresenter : IDisposable
    {
        Task InitializeAsync();
    }
}