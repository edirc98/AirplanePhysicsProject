//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Input/Test_InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Test_InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Test_InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Test_InputActions"",
    ""maps"": [
        {
            ""name"": ""BaseActionMap"",
            ""id"": ""f8921ce2-6a98-495f-8d3b-679c0fe7f63c"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""73e72e6e-bf38-45e6-abf5-53b0ba23af68"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""9810dad2-3f37-486b-a930-915ebea1553b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b9369a97-d304-4b67-bd43-da68be963ae5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3822f740-842a-4bb0-aa3e-cb7586eac5a7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";KeyBoard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ada4d53-d342-4817-ab6b-6bd52dd3bec1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e9bf05c3-15e0-4f95-836d-31d318c8affc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bdccdd3c-d095-4105-a0cb-4fb6624354aa"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";KeyBoard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""224c3ece-874f-4203-9b70-440af6f59618"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";KeyBoard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""15debd63-38e4-4ae8-a7e8-f1114d6c8d5c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";KeyBoard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2f59c772-393c-4698-ada5-1561116894cc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";KeyBoard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""faf23b3e-f6c1-4627-9626-c5e9e582ef7f"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd82db12-9f78-4dc1-a5fb-32b9339e04e2"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyBoard"",
            ""bindingGroup"": ""KeyBoard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<VirtualMouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Pointer>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // BaseActionMap
        m_BaseActionMap = asset.FindActionMap("BaseActionMap", throwIfNotFound: true);
        m_BaseActionMap_Jump = m_BaseActionMap.FindAction("Jump", throwIfNotFound: true);
        m_BaseActionMap_Movement = m_BaseActionMap.FindAction("Movement", throwIfNotFound: true);
        m_BaseActionMap_MouseMovement = m_BaseActionMap.FindAction("MouseMovement", throwIfNotFound: true);
    }

    ~@Test_InputActions()
    {
        UnityEngine.Debug.Assert(!m_BaseActionMap.enabled, "This will cause a leak and performance issues, Test_InputActions.BaseActionMap.Disable() has not been called.");
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // BaseActionMap
    private readonly InputActionMap m_BaseActionMap;
    private List<IBaseActionMapActions> m_BaseActionMapActionsCallbackInterfaces = new List<IBaseActionMapActions>();
    private readonly InputAction m_BaseActionMap_Jump;
    private readonly InputAction m_BaseActionMap_Movement;
    private readonly InputAction m_BaseActionMap_MouseMovement;
    public struct BaseActionMapActions
    {
        private @Test_InputActions m_Wrapper;
        public BaseActionMapActions(@Test_InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_BaseActionMap_Jump;
        public InputAction @Movement => m_Wrapper.m_BaseActionMap_Movement;
        public InputAction @MouseMovement => m_Wrapper.m_BaseActionMap_MouseMovement;
        public InputActionMap Get() { return m_Wrapper.m_BaseActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IBaseActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_BaseActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BaseActionMapActionsCallbackInterfaces.Add(instance);
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @MouseMovement.started += instance.OnMouseMovement;
            @MouseMovement.performed += instance.OnMouseMovement;
            @MouseMovement.canceled += instance.OnMouseMovement;
        }

        private void UnregisterCallbacks(IBaseActionMapActions instance)
        {
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @MouseMovement.started -= instance.OnMouseMovement;
            @MouseMovement.performed -= instance.OnMouseMovement;
            @MouseMovement.canceled -= instance.OnMouseMovement;
        }

        public void RemoveCallbacks(IBaseActionMapActions instance)
        {
            if (m_Wrapper.m_BaseActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBaseActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_BaseActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BaseActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BaseActionMapActions @BaseActionMap => new BaseActionMapActions(this);
    private int m_KeyBoardSchemeIndex = -1;
    public InputControlScheme KeyBoardScheme
    {
        get
        {
            if (m_KeyBoardSchemeIndex == -1) m_KeyBoardSchemeIndex = asset.FindControlSchemeIndex("KeyBoard");
            return asset.controlSchemes[m_KeyBoardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IBaseActionMapActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnMouseMovement(InputAction.CallbackContext context);
    }
}
