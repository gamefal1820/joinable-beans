// GENERATED AUTOMATICALLY FROM 'Assets/Input Actions/FreeCam.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FreeCam : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FreeCam()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FreeCam"",
    ""maps"": [
        {
            ""name"": ""Roaming"",
            ""id"": ""23a77c48-fd61-48f1-9bc9-5db7db6b8f9b"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""01bfd6b2-4e71-493c-8794-7dffcce04a5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Looking"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e10b6c6d-80c2-48cf-9c69-92d278673a06"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""228eeca7-fb0c-43d3-85bf-59c976345447"",
                    ""path"": ""<Gamepad>/leftStick/"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e585de01-6b73-4b23-bb5a-6e9e6ae1b679"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""523b9e52-9eae-43a5-af4b-bbe3bc6829c3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a82dc7e2-fe01-4ad4-ab20-96ee23bc5e3f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1cc5cd01-01a4-4404-9af8-2d78bed6b0a1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""41e8efd8-6eee-4da6-a4d5-5c2c0ec0ac81"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2603973f-ee02-4f71-85a1-a4ce62dc618d"",
                    ""path"": ""<Gamepad>/rightStick/"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Looking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1f5bfc2-1250-485e-ac53-9c529b682ddd"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Looking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Roaming
        m_Roaming = asset.FindActionMap("Roaming", throwIfNotFound: true);
        m_Roaming_Walk = m_Roaming.FindAction("Walk", throwIfNotFound: true);
        m_Roaming_Looking = m_Roaming.FindAction("Looking", throwIfNotFound: true);
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

    // Roaming
    private readonly InputActionMap m_Roaming;
    private IRoamingActions m_RoamingActionsCallbackInterface;
    private readonly InputAction m_Roaming_Walk;
    private readonly InputAction m_Roaming_Looking;
    public struct RoamingActions
    {
#pragma warning disable CS0436 // Type conflicts with imported type
		private @FreeCam m_Wrapper;
#pragma warning restore CS0436 // Type conflicts with imported type
#pragma warning disable CS0436 // Type conflicts with imported type
		public RoamingActions(@FreeCam wrapper) { m_Wrapper = wrapper; }
#pragma warning restore CS0436 // Type conflicts with imported type
		public InputAction @Walk => m_Wrapper.m_Roaming_Walk;
        public InputAction @Looking => m_Wrapper.m_Roaming_Looking;
        public InputActionMap Get() { return m_Wrapper.m_Roaming; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RoamingActions set) { return set.Get(); }
        public void SetCallbacks(IRoamingActions instance)
        {
            if (m_Wrapper.m_RoamingActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_RoamingActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_RoamingActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_RoamingActionsCallbackInterface.OnWalk;
                @Looking.started -= m_Wrapper.m_RoamingActionsCallbackInterface.OnLooking;
                @Looking.performed -= m_Wrapper.m_RoamingActionsCallbackInterface.OnLooking;
                @Looking.canceled -= m_Wrapper.m_RoamingActionsCallbackInterface.OnLooking;
            }
            m_Wrapper.m_RoamingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Looking.started += instance.OnLooking;
                @Looking.performed += instance.OnLooking;
                @Looking.canceled += instance.OnLooking;
            }
        }
    }
    public RoamingActions @Roaming => new RoamingActions(this);
    public interface IRoamingActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnLooking(InputAction.CallbackContext context);
    }
}
