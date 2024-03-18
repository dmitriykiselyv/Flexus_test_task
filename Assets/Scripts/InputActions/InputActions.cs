// GENERATED AUTOMATICALLY FROM 'Assets/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""CannonControl"",
            ""id"": ""2a3d3c1d-8118-4347-91d9-9e3ef5349494"",
            ""actions"": [
                {
                    ""name"": ""RotateBase"",
                    ""type"": ""Value"",
                    ""id"": ""50a47823-68bb-4035-9476-00bb5f6133e5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateBarrel"",
                    ""type"": ""Value"",
                    ""id"": ""b4163f71-b3f6-4286-a3dc-79c9a69b729f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""6f22994d-0a09-4fdf-9bc7-739bb7ae3ade"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AdjustFirePower"",
                    ""type"": ""Value"",
                    ""id"": ""882164c6-2a1c-4465-9006-4abd544e8476"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""LeftRight"",
                    ""id"": ""1e3ac0b1-ecf5-40fb-aefb-00b4d046eec0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateBase"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2a6e4320-df58-4f0e-8d13-3397a1a29c3b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateBase"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""19a10ab8-3cc5-4d39-a057-3a1c13050792"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateBase"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""TopDown"",
                    ""id"": ""8a70f081-2187-4e8b-8f99-4d011786bc55"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateBarrel"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1f7938ea-ae2a-4431-8b37-1162d2a34456"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateBarrel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""386023da-0c50-44b0-8059-c3420f7b3ea4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateBarrel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""60e14fb2-a039-41b2-8238-073601457e7b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53940b6d-dc04-483d-8903-8cbd8a4929c2"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdjustFirePower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CannonControl
        m_CannonControl = asset.FindActionMap("CannonControl", throwIfNotFound: true);
        m_CannonControl_RotateBase = m_CannonControl.FindAction("RotateBase", throwIfNotFound: true);
        m_CannonControl_RotateBarrel = m_CannonControl.FindAction("RotateBarrel", throwIfNotFound: true);
        m_CannonControl_Fire = m_CannonControl.FindAction("Fire", throwIfNotFound: true);
        m_CannonControl_AdjustFirePower = m_CannonControl.FindAction("AdjustFirePower", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // CannonControl
    private readonly InputActionMap m_CannonControl;
    private ICannonControlActions m_CannonControlActionsCallbackInterface;
    private readonly InputAction m_CannonControl_RotateBase;
    private readonly InputAction m_CannonControl_RotateBarrel;
    private readonly InputAction m_CannonControl_Fire;
    private readonly InputAction m_CannonControl_AdjustFirePower;
    public struct CannonControlActions
    {
        private @InputActions m_Wrapper;
        public CannonControlActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @RotateBase => m_Wrapper.m_CannonControl_RotateBase;
        public InputAction @RotateBarrel => m_Wrapper.m_CannonControl_RotateBarrel;
        public InputAction @Fire => m_Wrapper.m_CannonControl_Fire;
        public InputAction @AdjustFirePower => m_Wrapper.m_CannonControl_AdjustFirePower;
        public InputActionMap Get() { return m_Wrapper.m_CannonControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CannonControlActions set) { return set.Get(); }
        public void SetCallbacks(ICannonControlActions instance)
        {
            if (m_Wrapper.m_CannonControlActionsCallbackInterface != null)
            {
                @RotateBase.started -= m_Wrapper.m_CannonControlActionsCallbackInterface.OnRotateBase;
                @RotateBase.performed -= m_Wrapper.m_CannonControlActionsCallbackInterface.OnRotateBase;
                @RotateBase.canceled -= m_Wrapper.m_CannonControlActionsCallbackInterface.OnRotateBase;
                @RotateBarrel.started -= m_Wrapper.m_CannonControlActionsCallbackInterface.OnRotateBarrel;
                @RotateBarrel.performed -= m_Wrapper.m_CannonControlActionsCallbackInterface.OnRotateBarrel;
                @RotateBarrel.canceled -= m_Wrapper.m_CannonControlActionsCallbackInterface.OnRotateBarrel;
                @Fire.started -= m_Wrapper.m_CannonControlActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_CannonControlActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_CannonControlActionsCallbackInterface.OnFire;
                @AdjustFirePower.started -= m_Wrapper.m_CannonControlActionsCallbackInterface.OnAdjustFirePower;
                @AdjustFirePower.performed -= m_Wrapper.m_CannonControlActionsCallbackInterface.OnAdjustFirePower;
                @AdjustFirePower.canceled -= m_Wrapper.m_CannonControlActionsCallbackInterface.OnAdjustFirePower;
            }
            m_Wrapper.m_CannonControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RotateBase.started += instance.OnRotateBase;
                @RotateBase.performed += instance.OnRotateBase;
                @RotateBase.canceled += instance.OnRotateBase;
                @RotateBarrel.started += instance.OnRotateBarrel;
                @RotateBarrel.performed += instance.OnRotateBarrel;
                @RotateBarrel.canceled += instance.OnRotateBarrel;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @AdjustFirePower.started += instance.OnAdjustFirePower;
                @AdjustFirePower.performed += instance.OnAdjustFirePower;
                @AdjustFirePower.canceled += instance.OnAdjustFirePower;
            }
        }
    }
    public CannonControlActions @CannonControl => new CannonControlActions(this);
    public interface ICannonControlActions
    {
        void OnRotateBase(InputAction.CallbackContext context);
        void OnRotateBarrel(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnAdjustFirePower(InputAction.CallbackContext context);
    }
}
