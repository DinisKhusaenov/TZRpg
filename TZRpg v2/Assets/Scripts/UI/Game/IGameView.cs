using System;

namespace UI.Game
{
    public interface IGameView
    {
        event Action OnBackClicked;
    }
}