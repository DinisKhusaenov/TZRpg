using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public class MenuView : MonoBehaviour, IMenuView
    {
        public event Action OnGenerateClicked;
        public event Action OnPlayClicked;

        [SerializeField] private Button _generate;
        [SerializeField] private Button _play;

        private void Awake()
        {
            _play.onClick.AddListener(Play);
            _generate.onClick.AddListener(Generate);
        }

        private void OnDestroy()
        {
            _play.onClick.RemoveListener(Play);
            _generate.onClick.RemoveListener(Generate);
        }

        private void Play()
        {
            OnPlayClicked?.Invoke();
        }

        private void Generate()
        {
            OnGenerateClicked?.Invoke();
        }
    }
}