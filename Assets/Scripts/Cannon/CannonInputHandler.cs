using System;
using UnityEngine.InputSystem;

namespace Cannon
{
    public class CannonInputHandler
    {
        public event Action OnFire;
        public float HorizontalInput { get; private set; }
        public float VerticalInput { get; private set; }
    
        private readonly InputActions _inputActions;
    
        public CannonInputHandler(InputActions inputActions)
        {
            _inputActions = inputActions;
        
            RegisterInputEvents();
            EnableInputActions();
        }

        public void Cleanup()
        {
            UnregisterInputEvents();
            DisableInputActions();
        }
    
        private void RegisterInputEvents()
        {
            _inputActions.CannonControl.RotateBase.performed += OnRotateBasePerformed;
            _inputActions.CannonControl.RotateBase.canceled += OnRotateBaseCanceled;
            _inputActions.CannonControl.RotateBarrel.performed += OnRotateBarrelPerformed;
            _inputActions.CannonControl.RotateBarrel.canceled += OnRotateBarrelCanceled;
            _inputActions.CannonControl.Fire.performed += OnFirePerformed;
        }

        private void UnregisterInputEvents()
        {
            _inputActions.CannonControl.RotateBase.performed -= OnRotateBasePerformed;
            _inputActions.CannonControl.RotateBase.canceled -= OnRotateBaseCanceled;
            _inputActions.CannonControl.RotateBarrel.performed -= OnRotateBarrelPerformed;
            _inputActions.CannonControl.RotateBarrel.canceled -= OnRotateBarrelCanceled;
            _inputActions.CannonControl.Fire.performed -= OnFirePerformed;
        }
    
        private void OnRotateBasePerformed(InputAction.CallbackContext context)
        {
            HorizontalInput = context.ReadValue<float>();
        }

        private void OnRotateBaseCanceled(InputAction.CallbackContext context)
        {
            HorizontalInput = 0;
        }

        private void OnRotateBarrelPerformed(InputAction.CallbackContext context)
        {
            VerticalInput = context.ReadValue<float>();
        }

        private void OnRotateBarrelCanceled(InputAction.CallbackContext context)
        {
            VerticalInput = 0;
        }

        private void OnFirePerformed(InputAction.CallbackContext context)
        {
            OnFire?.Invoke();
        }

        private void EnableInputActions()
        {
            _inputActions.CannonControl.Enable();
        }
    
        private void DisableInputActions()
        {
            _inputActions.CannonControl.Disable();
        }
    }
}