using Configurations;
using MVC.Interfaces;
using MVC.Models;
using Projectile;
using UnityEngine;

namespace Cannon
{
    public class CannonController : MonoBehaviour, IObserver<SliderModel>
    {
        [SerializeField] private Transform _cannonStand;
        [SerializeField] private Transform _cannonBarrelAnchor;
        [SerializeField] private CannonConfig _cannonConfig;
        [SerializeField] private Transform _projectileLaunchPoint;
        
        private PowerSliderConfig _powerSliderConfig;
        private CannonInputHandler _cannonInputHandler;
        private GenericPool<ProjectileGenerator> _projectilePool;
        private float _initialSpeedMagnitude;
    
        public void Init(CannonInputHandler cannonInputHandler, PowerSliderConfig powerSliderConfig, GenericPool<ProjectileGenerator> projectilePool)
        {
            _cannonInputHandler = cannonInputHandler;
            _powerSliderConfig = powerSliderConfig;
            _projectilePool = projectilePool;

            _initialSpeedMagnitude = _powerSliderConfig.SliderModel.PowerValue;
            _powerSliderConfig.Attach(this);
            _cannonInputHandler.OnFire += Fire;
        }

        public void Cleanup()
        {
            _powerSliderConfig.Detach(this);
            _cannonInputHandler.OnFire -= Fire;
        }

        public void Update()
        {
            var horizontalInput = _cannonInputHandler.HorizontalInput;
            var verticalInput = _cannonInputHandler.VerticalInput;
            RotateStand(horizontalInput);
            RotateBarrel(verticalInput);
        }
    
        private void RotateStand(float input)
        {
            _cannonStand.Rotate(0, input * _cannonConfig.StandRotationMultiplier * Time.deltaTime, 0);
        }

        private void RotateBarrel(float input)
        {
            float currentRotationX = _cannonBarrelAnchor.localEulerAngles.x;

            if (currentRotationX > Constants.Constants.DEGREES_IN_HALF_CIRCLE)
            {
                currentRotationX -= Constants.Constants.DEGREES_IN_FULL_CIRCLE;
            }
        
            float newRotationX = Mathf.Clamp(currentRotationX + (input * _cannonConfig.BarrelRotationMultiplier * Time.deltaTime), _cannonConfig.BarrelElevationMin, _cannonConfig.BarrelElevationMax);

            var localEulerAngles = _cannonBarrelAnchor.localEulerAngles;
            localEulerAngles = new Vector3(newRotationX, localEulerAngles.y, localEulerAngles.z);
            _cannonBarrelAnchor.localEulerAngles = localEulerAngles;
        }

        private void Fire()
        {
            var projectile = _projectilePool.Get();
            projectile.transform.position = _projectileLaunchPoint.position;
            Vector3 initialVelocity = _projectileLaunchPoint.forward * _initialSpeedMagnitude;
            projectile.Init(initialVelocity, _projectilePool);
        }

        public void DataChanged(SliderModel data)
        {
            _initialSpeedMagnitude = data.PowerValue;
        }
    }
}