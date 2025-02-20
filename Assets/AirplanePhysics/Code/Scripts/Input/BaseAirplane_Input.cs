using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


namespace AirplanePhysics.AirplaneInputs
{
    public class BaseAirplane_Input : MonoBehaviour
    {

        #region VARIABLES
        protected float f_pitch = 0.0f;
        protected float f_roll = 0.0f;
        protected float f_yaw = 0.0f;
        protected float f_throttle = 0.0f;

        [SerializeField] protected int i_maxFlapsIncrements = 2;
        protected int i_flaps = 0;

        [SerializeField] protected KeyCode k_BrakeKey = KeyCode.Space;
        protected float f_brake = 0.0f;

        protected bool b_cameraSwitch = false;


        [Header("Input Sensitivity")]
        [Range(0, 1)] public float ThrottleSensitivity;
        [Range(0, 1)] public float RollSensitivity;
        [Range(0, 1)] public float RollBackSensitivity;
        //[Range(0, 1)] public float PitchSensitivity;
        //[Range(0, 1)] public float YawSensitivity;

        [Header("Input System Actions")]
        private AirplaneInputActions _airplaneActions;
        private PlayerInput _playerInput;

        #endregion

        #region PROPERTIES
        public float Pitch {  get { return f_pitch; } }
        public float Roll { get { return f_roll; } }
        public float Yaw { get { return f_yaw; } }
        public float Throttle { get { return f_throttle; } }
        public int Flaps { get { return i_flaps; } }
        public float FlapsNormalized { get { return (i_flaps / (float)i_maxFlapsIncrements); } 
        }
        public float Brake { get { return f_brake; } }
        public bool CameraSwitch { get { return b_cameraSwitch; } set { b_cameraSwitch = value; } }
        #endregion

        #region UNITY BUILT-IN METHODS
        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _airplaneActions = new AirplaneInputActions();
            _airplaneActions.AirplaneControls.Enable();
            SubscribeInputEvents();
        }
        void FixedUpdate()
        {
            HandleInput();
        }

        private void OnDisable()
        {
            _airplaneActions.AirplaneControls.Disable();
        }

        #endregion

        #region CUSTOM METHODS

        protected virtual void HandleInput()
        {

            //THROTTLE
            HandleThrottle();
            //ROLL
            HandleRoll();
            //PITCH && YAW
            HandlePitchYaw();
            //BrakeHandling
            HandleBrake();
        }



        protected virtual void HandleThrottle()
        {
            //THROTTLE
            float inputValue = _airplaneActions.AirplaneControls.Throttle.ReadValue<float>();
            if (inputValue != 0f)
            {
                f_throttle += ThrottleSensitivity * inputValue;
            }

            f_throttle = Mathf.Clamp01(f_throttle);
        }

        protected virtual void HandleRoll()
        {
            //ROLL
            float inputValue = _airplaneActions.AirplaneControls.Roll.ReadValue<float>();
            if (inputValue != 0f)
            {
                f_roll += RollSensitivity * inputValue;
            }
            else 
            {
                //Make roll come back to 0
                if (f_roll != 0)
                {
                    if (f_roll > 0.1f) f_roll -= RollBackSensitivity;
                    else if (f_roll < -0.1f) f_roll += RollBackSensitivity;
                    else f_roll = 0.0f;

                }
            }

            f_roll = Mathf.Clamp(f_roll,-1.0f,1.0f);
        }



        protected virtual void HandlePitchYaw()
        {
            bool usingGamepad = _playerInput.currentControlScheme.Equals(_airplaneActions.Airplane_GamepadScheme.name) ? true : false;

            Vector2 picthYawInput;

            if (usingGamepad) 
            {
                picthYawInput = _airplaneActions.AirplaneControls.PitchYawController.ReadValue<Vector2>();

                f_yaw = picthYawInput.x;
                f_pitch = picthYawInput.y;
            }
            else
            {
                picthYawInput = _airplaneActions.AirplaneControls.PitchYawMouse.ReadValue<Vector2>();

                float normalizedX = Mathf.InverseLerp(0, Screen.width, picthYawInput.x);
                float scaledNormalizedX = Mathf.Lerp(-1.0f, 1.0f, normalizedX);

                float normalizedY = Mathf.InverseLerp(0, Screen.height, picthYawInput.y);
                float scaledNormalizedY = Mathf.Lerp(-1.0f, 1.0f, normalizedY);

                f_yaw = scaledNormalizedX;
                f_pitch = scaledNormalizedY;
            }

            //Clamp Values
            f_pitch = Mathf.Clamp(f_pitch, -1.0f, 1.0f);
            f_yaw = Mathf.Clamp(f_yaw, -1.0f, 1.0f);

        }

        protected virtual void HandleBrake()
        {
            float inputValue = _airplaneActions.AirplaneControls.Brake.ReadValue<float>();
            f_brake = inputValue;
        }

        protected virtual void HandleFlapsUp(InputAction.CallbackContext context)
        {
            i_flaps++;
            i_flaps = Mathf.Clamp(i_flaps, 0, i_maxFlapsIncrements);
        }

        protected virtual void HandleFlapsDown(InputAction.CallbackContext context)
        {
            i_flaps--;
            i_flaps = Mathf.Clamp(i_flaps, 0, i_maxFlapsIncrements);
        }

        private void HandleCameraSwitch(InputAction.CallbackContext context)
        {
            b_cameraSwitch = true;
        }


        private void SubscribeInputEvents()
        {
            //Flaps
            _airplaneActions.AirplaneControls.FlapsUP.performed += HandleFlapsUp;
            _airplaneActions.AirplaneControls.FlapsDOWN.performed += HandleFlapsDown;

            //Camera switch
            _airplaneActions.AirplaneControls.CameraSwitch.performed += HandleCameraSwitch;

        }


        #endregion
    }
}

