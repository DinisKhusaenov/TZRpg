using System;
using Character.Config;
using Character.Factory;
using Services.Character;
using UI.Menu;
using UnityEngine;

public class MenuBootstrap : MonoBehaviour
{
    [SerializeField] private CharacterConfig _characterConfig;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private MenuView _menuView;

    private IMenuPresenter _menuPresenter;
    private ICharacterFactory _characterFactory;
    private ICharacterAcquisitionService _characterAcquisition;

    private void Awake()
    {
        _characterFactory = new CharacterFactory(_characterConfig);
        _characterAcquisition = new RandomCharacterAcquisitionService(_characterConfig);
        _menuPresenter = new MenuPresenter(_menuView, _characterFactory, _characterAcquisition);
        
        _menuPresenter.Initialize(_spawnPosition);
    }

    private void OnDestroy()
    {
        _menuPresenter.Dispose();
    }
}