using MVC.Models;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MVC.Controllers
{
    public class PowerSliderController
    {
        private readonly PowerSliderConfig _config;
        private readonly InputActions _inputActions;

        public PowerSliderController(PowerSliderConfig config, InputActions inputActions)
        {
            _config = config;
            _inputActions = inputActions;
        
            _inputActions.CannonControl.AdjustFirePower.performed += OnAdjustFirePowerPerformed;
        }
    
        public void Cleanup()
        {
            _inputActions.CannonControl.AdjustFirePower.performed -= OnAdjustFirePowerPerformed;
        }
    
        private void OnAdjustFirePowerPerformed(InputAction.CallbackContext context)
        {
            var scrollValue = context.ReadValue<Vector2>().normalized.y;
            AdjustPowerValue(scrollValue);
        }
    
        private void AdjustPowerValue(float scrollValue)
        {
            float sensitivity = _config.SliderModel.ScrollSensitivity;
            float newPowerValue = _config.SliderModel.PowerValue + (scrollValue * sensitivity);
        
            newPowerValue = Mathf.Clamp(newPowerValue, _config.SliderModel.MinPowerValue, _config.SliderModel.MaxPowerValue);

            SliderModel model = _config.SliderModel;
            model.UpdatePowerValue(newPowerValue);
            _config.SliderModel = model;
        }
    }
}