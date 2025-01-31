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


        [Header("Input Sensitivity")]
        [Range(0, 1)] public float ThrottleSensitivity;
        [Range(0, 1)] public float RollSensitivity;



        [SerializeField] private Vector2 screenCenter = new Vector2 (Screen.width / 2, Screen.height / 2);
        #endregion

        #region PROPERTIES
        public float Pitch {  get { return f_pitch; } }
        public float Roll { get { return f_roll; } }
        public float Yaw { get { return f_yaw; } }
        public float Throttle { get { return f_throttle; } }
        public float Flaps { get { return i_flaps; } }
        public float Brake { get { return f_brake; } }
        #endregion

        #region UNITY BUILT-IN METHODS

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

            Vector2 mousePos = Input.mousePosition;
            Vector2 mousePosCentered = new Vector2(mousePos.x -= screenCenter.x, mousePos.y -= screenCenter.y);

            Vector2 MouseDirection = mousePosCentered - screenCenter;

            Debug.Log("MousePos X,Y: " + MouseDirection.x + ", " + MouseDirection.y);
            
            //PITCH
            HandlePitch();
            //YAW
            HandleYaw();
            
            


            //Main Input Handling
            //f_pitch = Input.GetAxis("Vertical");
            //f_roll = Input.GetAxis("Horizontal");
            //f_yaw = Input.GetAxis("Yaw");
            //f_throttle = Input.GetAxis("Throttle");

            //Brake Handling
            f_brake = Input.GetKey(k_BrakeKey) ? 1.0f : 0.0f;

            //Flaps Handling
            if (Input.GetKeyDown(KeyCode.F))
            {
                i_flaps++;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                i_flaps--;
            }

            i_flaps = Mathf.Clamp(i_flaps, 0, i_maxFlapsIncrements);
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

        protected virtual void HandleYaw()
        {

        }

        protected virtual void HandlePitch()
        {

        }
        #endregion
    }
}

