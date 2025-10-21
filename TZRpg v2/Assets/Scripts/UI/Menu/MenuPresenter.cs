using System;
using Character;
using Character.Factory;
using Common;
using Services.Character;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace UI.Menu
{
    public class MenuPresenter : IMenuPresenter
    {
        private readonly IMenuView _menuView;
        private readonly ICharacterFactory _factory;
        private readonly ICharacterAcquisitionService _characterAcquisitionService;
        
        private Transform _generatePosition;
        private ICharacterView _currentView;

        public MenuPresenter(IMenuView menuView, ICharacterFactory factory, ICharacterAcquisitionService characterAcquisitionService)
        {
            _menuView = menuView;
            _factory = factory;
            _characterAcquisitionService = characterAcquisitionService;
        }

        public void Initialize(Transform generatePosition)
        {
            _generatePosition = generatePosition;
            
            _menuView.OnPlayClicked += PlayClicked;
            _menuView.OnGenerateClicked += GenerateClicked;
            InitialSpawn();
        }
        
        public void Dispose()
        {
            _menuView.OnPlayClicked -= PlayClicked;
            _menuView.OnGenerateClicked -= GenerateClicked;
        }

        private void InitialSpawn()
        {
            if (PlayerPrefs.HasKey(DataBaseConstants.CharacterKey))
                CreateCharacter((CharacterType)PlayerPrefs.GetInt(DataBaseConstants.CharacterKey));
            else
                CreateCharacter(CharacterType.Character0);
        }

        private void PlayClicked()
        {
            SceneManager.LoadScene(SceneNames.Game);
        }

        private void GenerateClicked()
        {
            if (_currentView != null)
            {
                Object.Destroy(_currentView.gameObject);
            }

            CreateCharacter(_characterAcquisitionService.GetView().Type);
            Save();
        }

        private void CreateCharacter(CharacterType type)
        {
            _currentView = _factory.CreateCharacter(type, _generatePosition.position);
        }

        private void Save()
        {
            PlayerPrefs.SetInt(DataBaseConstants.CharacterKey, (int)_currentView.Type);
        }
    }
}