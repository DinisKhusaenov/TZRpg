using Character;
using Character.Factory;
using Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Game
{
    public class GamePresenter : IGamePresenter
    {
        private readonly ICharacterFactory _characterFactory;
        private readonly IGameView _gameView;
        
        private Transform _spawnPosition;
        private ICharacterView _currentView;

        public GamePresenter(IGameView gameView, ICharacterFactory characterFactory)
        {
            _gameView = gameView;
            _characterFactory = characterFactory;
        }

        public void Initialize(Transform spawnPosition)
        {
            _spawnPosition = spawnPosition;
            SpawnCharacter();

            _gameView.OnBackClicked += BackClicked;
        }

        public void Dispose()
        {
            _gameView.OnBackClicked -= BackClicked;
        }

        private void BackClicked()
        {
            SceneManager.LoadScene(SceneNames.Menu);
        }

        private void SpawnCharacter()
        {
            int id = PlayerPrefs.GetInt(DataBaseConstants.CharacterKey);
            _currentView = _characterFactory.CreateCharacter((CharacterType)id, _spawnPosition.position);
        }
    }
}