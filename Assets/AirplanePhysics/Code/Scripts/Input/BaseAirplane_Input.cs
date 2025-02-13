using System;
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

        [SerializeField] protected KeyCode k_CameraSwitch = KeyCode.C;
        protected bool b_cameraSwitch = false;


        [Header("Input Sensitivity")]
        [Range(0, 1)] public float ThrottleSensitivity;
        [Range(0, 1)] public float RollSensitivity;
        [Range(0, 1)] public float PitchSensitivity;
        [Range(0, 1)] public float YawSensitivity;

        [Tooltip("Mouse center dead zone in pixels")]
        public float MouseDeadZone = 60.0f;



        [SerializeField] private Vector2 screenCenter;
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
        public bool CameraSwitch { get { return b_cameraSwitch; } }
        #endregion

        #region UNITY BUILT-IN METHODS
        private void Awake()
        {
            screenCenter =  new Vector2(Screen.width / 2, Screen.height / 2);
        }
        void FixedUpdate()
        {
            HandleInput();
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
            //Flaps Handling
            HandleFlaps();
            //BrakeHandling
            HandleBrake();
            //Camera Swithc
            HandleCameraSwitch();
            
        }



        protected virtual void HandleThrottle()
        {
            //THROTTLE
            if (Input.GetKey(KeyCode.W))
            {
                f_throttle += ThrottleSensitivity;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                f_throttle -= ThrottleSensitivity;
            }
            f_throttle = Mathf.Clamp01(f_throttle);
        }

        protected virtual void HandleRoll()
        {
            //THROTTLE
            if (Input.GetKey(KeyCode.A))
            {
                f_roll -= RollSensitivity;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                f_roll += RollSensitivity;
            }
            else
            {
                if (f_roll != 0)
                {
                    if (f_roll > 0.1f) f_roll -= RollSensitivity;
                    else if (f_roll < -0.1f) f_roll += RollSensitivity;
                    else f_roll = 0.0f;

                }
            }
            f_roll = Mathf.Clamp(f_roll,-1.0f,1.0f);
        }

        protected virtual void HandlePitchYaw()
        {
            Vector2 mousePos = Mouse.current.position.value;

            float normalizedX = Mathf.InverseLerp(0, Screen.width, mousePos.x);
            float scaledNormalizedX = Mathf.Lerp(-1.0f, 1.0f, normalizedX);

            float normalizedY = Mathf.InverseLerp(0, Screen.height, mousePos.y);
            float scaledNormalizedY = Mathf.Lerp(-1.0f, 1.0f, normalizedY);

            f_yaw = scaledNormalizedX;
            f_pitch = scaledNormalizedY;

            //Clamp Values
            f_pitch = Mathf.Clamp(f_pitch, -1.0f, 1.0f);
            f_yaw = Mathf.Clamp(f_yaw, -1.0f, 1.0f);

        }

        protected virtual void HandleBrake()
        {
            f_brake = Input.GetKey(k_BrakeKey) ? 1.0f : 0.0f;
        }

        protected virtual void HandleFlaps()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                i_flaps++;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                i_flaps--;
            }

            i_flaps = Mathf.Clamp(i_flaps, 0, i_maxFlapsIncrements);
        }

        private void HandleCameraSwitch()
        {
            b_cameraSwitch = Input.GetKeyDown(k_CameraSwitch);
        }
        #endregion
    }
}

