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

        void Update()
        {
            HandleInput();
        }

        #endregion

        #region CUSTOM METHODS

        protected virtual void HandleInput()
        {
            //Main Input Handling
            f_pitch = Input.GetAxis("Vertical");
            f_roll = Input.GetAxis("Horizontal");
            f_yaw = Input.GetAxis("Yaw");
            f_throttle = Input.GetAxis("Throttle");

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
        #endregion
    }
}

