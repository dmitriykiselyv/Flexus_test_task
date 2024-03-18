using Cannon;
using Configurations;
using MVC.Controllers;
using MVC.Models;
using MVC.Views;
using Projectile;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private CannonController _cannonController;
    [SerializeField] private CannonRecoil _cannonRecoil;
    [SerializeField] private PowerControlView _powerControlView;
    [SerializeField] private CameraShake _cameraShake;
    [SerializeField] private PowerSliderConfig _powerSliderConfig;
    [SerializeField] private ProjectileConfig _projectileConfig;
    [SerializeField] private Transform _projectileParent;
    [SerializeField] private DecalPool _decalPool;
    [SerializeField] private DecalPoolConfig _decalPoolConfig;
    
    private PowerSliderController _powerSliderController;
    private CannonInputHandler _cannonInputHandler;
    private InputActions _inputActions;
    private GenericPool<ProjectileGenerator> _projectilePool;

    private void Awake()
    {
        _inputActions = new InputActions();
        _cannonInputHandler = new CannonInputHandler(_inputActions);
        _projectilePool = new GenericPool<ProjectileGenerator>(_projectileConfig.Prefab, _projectileConfig.InitialSize, _projectileParent);
        _decalPool.Init(_decalPoolConfig, _projectilePool);
        _cannonController.Init(_cannonInputHandler, _powerSliderConfig, _projectilePool);
        _cannonRecoil.Init(_cannonInputHandler);
        _cameraShake.Init(_cannonInputHandler);
        _powerControlView.Init(_powerSliderConfig);
        _powerSliderController = new PowerSliderController(_powerSliderConfig, _inputActions);
    }

    private void OnDestroy()
    {
        _cannonInputHandler.Cleanup();
        _decalPool.Cleanup();
        _cannonController.Cleanup();
        _cannonRecoil.Cleanup();
        _cameraShake.Cleanup();
        _powerControlView.Cleanup();
        _powerSliderController.Cleanup();
    }
}