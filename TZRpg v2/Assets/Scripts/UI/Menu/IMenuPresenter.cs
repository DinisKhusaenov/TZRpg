using System;
using UnityEngine;

namespace UI.Menu
{
    public interface IMenuPresenter : IDisposable
    {
        void Initialize(Transform generatePosition);
    }
}