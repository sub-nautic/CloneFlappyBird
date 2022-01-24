// GENERATED AUTOMATICALLY FROM 'Assets/Content/Input/BirdInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @BirdInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @BirdInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BirdInput"",
    ""maps"": [
        {
            ""name"": ""Bird"",
            ""id"": ""1131b45b-3e61-4db4-b2d6-a960989e5f55"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""eeea9f78-166e-43ae-a2f0-891a4712b671"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""3c0af0f9-09a9-46f0-81ef-559e92f71daa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f985329d-590f-47aa-bf20-edbed7183c7d"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41e642ee-9434-4aae-b189-d7d982cbde54"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57883b02-5dcc-4489-92fa-d70dd4a58817"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Bird
        m_Bird = asset.FindActionMap("Bird", throwIfNotFound: true);
        m_Bird_Jump = m_Bird.FindAction("Jump", throwIfNotFound: true);
        m_Bird_Quit = m_Bird.FindAction("Quit", throwIfNotFound: true);
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

    // Bird
    private readonly InputActionMap m_Bird;
    private IBirdActions m_BirdActionsCallbackInterface;
    private readonly InputAction m_Bird_Jump;
    private readonly InputAction m_Bird_Quit;
    public struct BirdActions
    {
        private @BirdInput m_Wrapper;
        public BirdActions(@BirdInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Bird_Jump;
        public InputAction @Quit => m_Wrapper.m_Bird_Quit;
        public InputActionMap Get() { return m_Wrapper.m_Bird; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BirdActions set) { return set.Get(); }
        public void SetCallbacks(IBirdActions instance)
        {
            if (m_Wrapper.m_BirdActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_BirdActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BirdActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BirdActionsCallbackInterface.OnJump;
                @Quit.started -= m_Wrapper.m_BirdActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_BirdActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_BirdActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_BirdActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public BirdActions @Bird => new BirdActions(this);
    public interface IBirdActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
}
