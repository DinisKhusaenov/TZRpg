using Character.Config;
using Character.Factory;
using UI.Game;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private GameView _gameView;
    [SerializeField] private CharacterConfig _characterConfig;
    [SerializeField] private Transform _spawnPosition;

    private ICharacterFactory _characterFactory;
    private IGamePresenter _gamePresenter;

    private void Awake()
    {
        _characterFactory = new CharacterFactory(_characterConfig);
        _gamePresenter = new GamePresenter(_gameView, _characterFactory);
        _gamePresenter.Initialize(_spawnPosition);
    }
}