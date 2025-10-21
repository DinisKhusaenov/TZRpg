using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game
{
    public class GameView : MonoBehaviour, IGameView
    {
        public event Action OnBackClicked;
        
        [SerializeField] private Button _back;

        private void Awake()
        {
            _back.onClick.AddListener(Back);
        }

        private void OnDestroy()
        {
            _back.onClick.RemoveListener(Back);
        }

        private void Back()
        {
            OnBackClicked?.Invoke();
        }
    }
}