using AirplanePhysics.AirplaneInputs;
using UnityEngine;

namespace AirplanePhysics.Component
{
    public enum ControlSurfaceType
    {
        RUDDER,
        ELEVATOR,
        AILERON,
        FLAP
    }
    public class Airplane_ControlSurface : MonoBehaviour
    {

        #region VARIABLES
        [Header("Control Surface Properties")]
        public ControlSurfaceType surfaceType = ControlSurfaceType.RUDDER;
        public float maxRotatioAngle = 30.0f;
        public Vector3 rotationAxis;
        public float smoothSpeed;


        [Header("Control Surface Object")]
        public Transform controlSurfaceTransform;
        private Vector3 controlSurfaceStartRotation; 

        [SerializeField] private Vector3 wantedRotation;
        #endregion


        #region UNITY BUILT-IN METHODS
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            controlSurfaceStartRotation = controlSurfaceTransform.rotation.eulerAngles;
        }

        // Update is called once per frame
        void Update()
        {
            if (controlSurfaceTransform != null) 
            {                
                controlSurfaceTransform.localRotation = Quaternion.Lerp(controlSurfaceTransform.localRotation, Quaternion.Euler(wantedRotation), Time.deltaTime * smoothSpeed);
            }
        }
        #endregion

        #region CUSTOM METHODS

        public void HandleControlSurface(BaseAirplane_Input input)
        {
            float inputValue = 0.0f;

            switch (surfaceType) {
                case ControlSurfaceType.RUDDER:
                    inputValue = input.Yaw;
                    break;
                case ControlSurfaceType.ELEVATOR:
                    inputValue = input.Pitch;
                    break;
                case ControlSurfaceType.FLAP:
                    inputValue = input.Flaps;
                    break;
                case ControlSurfaceType.AILERON:
                    inputValue = input.Roll;
                    break;
                default:
                    break;

            }

            wantedRotation = controlSurfaceStartRotation + ((maxRotatioAngle * inputValue) * rotationAxis); //Input value comes form 0 to 
        }
        #endregion

    }
}

