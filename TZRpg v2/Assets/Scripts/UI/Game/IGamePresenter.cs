using System;
using UnityEngine;

namespace UI.Game
{
    public interface IGamePresenter: IDisposable
    {
        void Initialize(Transform spawnPosition);
    }
}