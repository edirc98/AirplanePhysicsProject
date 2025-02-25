//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/AirplanePhysics/Code/Scripts/Input/AirplaneInputActions.inputactions
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

public partial class @AirplaneInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @AirplaneInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""AirplaneInputActions"",
    ""maps"": [
        {
            ""name"": ""AirplaneControls"",
            ""id"": ""79725fb6-8b7e-4dab-9ef6-eb5482ce3acf"",
            ""actions"": [
                {
                    ""name"": ""Roll"",
                    ""type"": ""Value"",
                    ""id"": ""fe041cae-c644-4265-b486-3eae53495c20"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Throttle"",
                    ""type"": ""Value"",
                    ""id"": ""b375e5ad-7fe3-44ae-9766-7a805a3c2ca3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Button"",
                    ""id"": ""45f11c58-4093-47b1-af9f-08ac2caa5d28"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FlapsUP"",
                    ""type"": ""Button"",
                    ""id"": ""77d9e6ab-9160-4409-8bcd-03982ca9df48"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FlapsDOWN"",
                    ""type"": ""Button"",
                    ""id"": ""51667615-5b2c-4031-a46f-8ecd7b22ea45"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CameraSwitch"",
                    ""type"": ""Button"",
                    ""id"": ""7f95e4f8-a148-485e-a1da-c621f1cb2405"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PitchYawMouse"",
                    ""type"": ""Value"",
                    ""id"": ""7dcde984-cec9-421d-8b3d-c3fd602adb51"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PitchYawController"",
                    ""type"": ""Value"",
                    ""id"": ""cbe1b64b-5f8e-4e51-9904-277f2a01bb90"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MotorToggle"",
                    ""type"": ""Button"",
                    ""id"": ""de7cfc6e-b746-407d-be61-c73ec221b675"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8cea008a-4230-4270-90fd-d0b92c55e854"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Airplane_Keyboard"",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfdee0e3-e289-4635-9b32-006d982b215c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Airplane_Gamepad"",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""7f395e02-3d69-4b36-9e30-58f28ec93bbb"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""bf00e9dd-7147-4b44-9a4a-764ecff0322f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Airplane_Keyboard"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""950d8031-7673-4c5e-b2bc-76597df548bd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Airplane_Keyboard"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""dcf64077-a294-4c52-bb0a-11394c46b167"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""4d11e9ac-803c-42f9-a585-c8355936d6b9"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Airplane_Gamepad"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""ba09ac1a-d9c4-45fb-89d0-43889f08bdaa"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Airplane_Gamepad"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2ff5daee-b746-4c51-ab93-88eeb4e39eef"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Airplane_Keyboard"",
                    ""action"": ""FlapsUP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba3d1b76-5bdc-4471-8bdc-5634045c63ec"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Airplane_Gamepad"",
                    ""action"": ""FlapsUP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57bbd782-664e-4768-ab0b-1bdf64423d5a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Airplane_Keyboard"",
                    ""action"": ""FlapsDOWN"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8da6c1ed-3154-4947-9cc6-74b110ac6c50"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Airplane_Gamepad"",
                    ""action"": ""FlapsDOWN"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49599b56-6009-4a9d-a2d1-9c1c7d168ea6"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Airplane_Keyboard"",
                    ""action"": ""CameraSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0da7db5-3353-4837-a19d-9aa75425ae9b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Airplane_Gamepad"",
                    ""action"": ""CameraSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b12e6844-f88c-4cd9-997a-786e1454d594"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Airplane_Keyboard"",
                    ""action"": ""PitchYawMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""87fd2201-2dfd-4a95-98d6-f1c597cc8a5a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""fad2e392-a079-4ff3-abd9-df62e21d5487"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Airplane_Keyboard"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""95f2370a-4879-4715-b8d5-b2b06ccd4257"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Airplane_Keyboard"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e787d4e5-e05e-4f3e-9f45-b2e181e1e024"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Airplane_Gamepad"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aaec6d64-d22d-4807-9ae4-973f2b9f6a9f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false)"",
                    ""groups"": "";Airplane_Gamepad"",
                    ""action"": ""PitchYawController"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74209719-da90-4039-a5d1-c818029d948b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Hold(duration=0.8,pressPoint=0.5)"",
                    ""processors"": """",
                    ""groups"": "";Airplane_Keyboard"",
                    ""action"": ""MotorToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73fd5015-863d-4cd4-a624-3432f8378474"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Hold(duration=0.8,pressPoint=0.5)"",
                    ""processors"": """",
                    ""groups"": "";Airplane_Gamepad"",
                    ""action"": ""MotorToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Airplane_Keyboard"",
            ""bindingGroup"": ""Airplane_Keyboard"",
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
                }
            ]
        },
        {
            ""name"": ""Airplane_Gamepad"",
            ""bindingGroup"": ""Airplane_Gamepad"",
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
        // AirplaneControls
        m_AirplaneControls = asset.FindActionMap("AirplaneControls", throwIfNotFound: true);
        m_AirplaneControls_Roll = m_AirplaneControls.FindAction("Roll", throwIfNotFound: true);
        m_AirplaneControls_Throttle = m_AirplaneControls.FindAction("Throttle", throwIfNotFound: true);
        m_AirplaneControls_Brake = m_AirplaneControls.FindAction("Brake", throwIfNotFound: true);
        m_AirplaneControls_FlapsUP = m_AirplaneControls.FindAction("FlapsUP", throwIfNotFound: true);
        m_AirplaneControls_FlapsDOWN = m_AirplaneControls.FindAction("FlapsDOWN", throwIfNotFound: true);
        m_AirplaneControls_CameraSwitch = m_AirplaneControls.FindAction("CameraSwitch", throwIfNotFound: true);
        m_AirplaneControls_PitchYawMouse = m_AirplaneControls.FindAction("PitchYawMouse", throwIfNotFound: true);
        m_AirplaneControls_PitchYawController = m_AirplaneControls.FindAction("PitchYawController", throwIfNotFound: true);
        m_AirplaneControls_MotorToggle = m_AirplaneControls.FindAction("MotorToggle", throwIfNotFound: true);
    }

    ~@AirplaneInputActions()
    {
        UnityEngine.Debug.Assert(!m_AirplaneControls.enabled, "This will cause a leak and performance issues, AirplaneInputActions.AirplaneControls.Disable() has not been called.");
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

    // AirplaneControls
    private readonly InputActionMap m_AirplaneControls;
    private List<IAirplaneControlsActions> m_AirplaneControlsActionsCallbackInterfaces = new List<IAirplaneControlsActions>();
    private readonly InputAction m_AirplaneControls_Roll;
    private readonly InputAction m_AirplaneControls_Throttle;
    private readonly InputAction m_AirplaneControls_Brake;
    private readonly InputAction m_AirplaneControls_FlapsUP;
    private readonly InputAction m_AirplaneControls_FlapsDOWN;
    private readonly InputAction m_AirplaneControls_CameraSwitch;
    private readonly InputAction m_AirplaneControls_PitchYawMouse;
    private readonly InputAction m_AirplaneControls_PitchYawController;
    private readonly InputAction m_AirplaneControls_MotorToggle;
    public struct AirplaneControlsActions
    {
        private @AirplaneInputActions m_Wrapper;
        public AirplaneControlsActions(@AirplaneInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Roll => m_Wrapper.m_AirplaneControls_Roll;
        public InputAction @Throttle => m_Wrapper.m_AirplaneControls_Throttle;
        public InputAction @Brake => m_Wrapper.m_AirplaneControls_Brake;
        public InputAction @FlapsUP => m_Wrapper.m_AirplaneControls_FlapsUP;
        public InputAction @FlapsDOWN => m_Wrapper.m_AirplaneControls_FlapsDOWN;
        public InputAction @CameraSwitch => m_Wrapper.m_AirplaneControls_CameraSwitch;
        public InputAction @PitchYawMouse => m_Wrapper.m_AirplaneControls_PitchYawMouse;
        public InputAction @PitchYawController => m_Wrapper.m_AirplaneControls_PitchYawController;
        public InputAction @MotorToggle => m_Wrapper.m_AirplaneControls_MotorToggle;
        public InputActionMap Get() { return m_Wrapper.m_AirplaneControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AirplaneControlsActions set) { return set.Get(); }
        public void AddCallbacks(IAirplaneControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_AirplaneControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AirplaneControlsActionsCallbackInterfaces.Add(instance);
            @Roll.started += instance.OnRoll;
            @Roll.performed += instance.OnRoll;
            @Roll.canceled += instance.OnRoll;
            @Throttle.started += instance.OnThrottle;
            @Throttle.performed += instance.OnThrottle;
            @Throttle.canceled += instance.OnThrottle;
            @Brake.started += instance.OnBrake;
            @Brake.performed += instance.OnBrake;
            @Brake.canceled += instance.OnBrake;
            @FlapsUP.started += instance.OnFlapsUP;
            @FlapsUP.performed += instance.OnFlapsUP;
            @FlapsUP.canceled += instance.OnFlapsUP;
            @FlapsDOWN.started += instance.OnFlapsDOWN;
            @FlapsDOWN.performed += instance.OnFlapsDOWN;
            @FlapsDOWN.canceled += instance.OnFlapsDOWN;
            @CameraSwitch.started += instance.OnCameraSwitch;
            @CameraSwitch.performed += instance.OnCameraSwitch;
            @CameraSwitch.canceled += instance.OnCameraSwitch;
            @PitchYawMouse.started += instance.OnPitchYawMouse;
            @PitchYawMouse.performed += instance.OnPitchYawMouse;
            @PitchYawMouse.canceled += instance.OnPitchYawMouse;
            @PitchYawController.started += instance.OnPitchYawController;
            @PitchYawController.performed += instance.OnPitchYawController;
            @PitchYawController.canceled += instance.OnPitchYawController;
            @MotorToggle.started += instance.OnMotorToggle;
            @MotorToggle.performed += instance.OnMotorToggle;
            @MotorToggle.canceled += instance.OnMotorToggle;
        }

        private void UnregisterCallbacks(IAirplaneControlsActions instance)
        {
            @Roll.started -= instance.OnRoll;
            @Roll.performed -= instance.OnRoll;
            @Roll.canceled -= instance.OnRoll;
            @Throttle.started -= instance.OnThrottle;
            @Throttle.performed -= instance.OnThrottle;
            @Throttle.canceled -= instance.OnThrottle;
            @Brake.started -= instance.OnBrake;
            @Brake.performed -= instance.OnBrake;
            @Brake.canceled -= instance.OnBrake;
            @FlapsUP.started -= instance.OnFlapsUP;
            @FlapsUP.performed -= instance.OnFlapsUP;
            @FlapsUP.canceled -= instance.OnFlapsUP;
            @FlapsDOWN.started -= instance.OnFlapsDOWN;
            @FlapsDOWN.performed -= instance.OnFlapsDOWN;
            @FlapsDOWN.canceled -= instance.OnFlapsDOWN;
            @CameraSwitch.started -= instance.OnCameraSwitch;
            @CameraSwitch.performed -= instance.OnCameraSwitch;
            @CameraSwitch.canceled -= instance.OnCameraSwitch;
            @PitchYawMouse.started -= instance.OnPitchYawMouse;
            @PitchYawMouse.performed -= instance.OnPitchYawMouse;
            @PitchYawMouse.canceled -= instance.OnPitchYawMouse;
            @PitchYawController.started -= instance.OnPitchYawController;
            @PitchYawController.performed -= instance.OnPitchYawController;
            @PitchYawController.canceled -= instance.OnPitchYawController;
            @MotorToggle.started -= instance.OnMotorToggle;
            @MotorToggle.performed -= instance.OnMotorToggle;
            @MotorToggle.canceled -= instance.OnMotorToggle;
        }

        public void RemoveCallbacks(IAirplaneControlsActions instance)
        {
            if (m_Wrapper.m_AirplaneControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAirplaneControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_AirplaneControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AirplaneControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AirplaneControlsActions @AirplaneControls => new AirplaneControlsActions(this);
    private int m_Airplane_KeyboardSchemeIndex = -1;
    public InputControlScheme Airplane_KeyboardScheme
    {
        get
        {
            if (m_Airplane_KeyboardSchemeIndex == -1) m_Airplane_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Airplane_Keyboard");
            return asset.controlSchemes[m_Airplane_KeyboardSchemeIndex];
        }
    }
    private int m_Airplane_GamepadSchemeIndex = -1;
    public InputControlScheme Airplane_GamepadScheme
    {
        get
        {
            if (m_Airplane_GamepadSchemeIndex == -1) m_Airplane_GamepadSchemeIndex = asset.FindControlSchemeIndex("Airplane_Gamepad");
            return asset.controlSchemes[m_Airplane_GamepadSchemeIndex];
        }
    }
    public interface IAirplaneControlsActions
    {
        void OnRoll(InputAction.CallbackContext context);
        void OnThrottle(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnFlapsUP(InputAction.CallbackContext context);
        void OnFlapsDOWN(InputAction.CallbackContext context);
        void OnCameraSwitch(InputAction.CallbackContext context);
        void OnPitchYawMouse(InputAction.CallbackContext context);
        void OnPitchYawController(InputAction.CallbackContext context);
        void OnMotorToggle(InputAction.CallbackContext context);
    }
}
