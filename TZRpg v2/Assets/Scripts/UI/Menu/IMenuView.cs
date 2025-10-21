using System;

namespace UI.Menu
{
    public interface IMenuView
    {
        event Action OnGenerateClicked;
        event Action OnPlayClicked;
    }
}