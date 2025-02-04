using AirplanePhysics.AirplaneInputs;
using UnityEngine;


namespace AirplanePhysics.Component
{
    [RequireComponent(typeof(WheelCollider))]
    public class Airplane_Wheel : MonoBehaviour
    {
        #region VARIABLES
        [Header("Wheel Properties")]
        public Transform wheelTransform;
        [Header("Brake Properties")]
        public bool isBraking = false;
        public float brakeForce = 5.0f;
        [Header("Steering Properties")]
        public bool isSteering = false;
        public float steerAngle = 20.0f; 
        public float steerSmoothSpeed = 1.0f;




        private WheelCollider _wheelCollider;
        private Vector3 _worldPos; 
        private Quaternion _worldRot;
        private float finalBrakeForce;
        private float finalSteerAngle;
        #endregion

        #region UNITY BUILT-IN METHODS
        void Start()
        {
            _wheelCollider = GetComponent<WheelCollider>();
        }
        #endregion

        #region CUSTOM METHODS
        public void InitWheel()
        {
            if( _wheelCollider != null)
            {
                _wheelCollider.motorTorque = 0.000001f;
            }
        }

        public void HandleWheel(BaseAirplane_Input input)
        {
            if (_wheelCollider != null) 
            {
                _wheelCollider.GetWorldPose(out _worldPos, out _worldRot);
                if (wheelTransform != null) 
                {
                    wheelTransform.position = _worldPos;
                    wheelTransform.rotation = _worldRot;
                }

                if (isBraking) 
                {
                    //Handle Brake
                    if (input.Brake > 0.1f)
                    {
                        finalBrakeForce = Mathf.Lerp(finalBrakeForce, input.Brake * brakeForce, Time.deltaTime);
                        _wheelCollider.brakeTorque = finalBrakeForce;
                    }
                    else
                    {
                        finalBrakeForce = 0.0f;
                        _wheelCollider.brakeTorque = 0.0f;
                        _wheelCollider.motorTorque = 0.000001f;
                    }
                }

                if(isSteering)
                {
                    finalSteerAngle = Mathf.Lerp(finalSteerAngle, -input.Yaw * steerAngle, Time.deltaTime * steerSmoothSpeed);
                    _wheelCollider.steerAngle = finalSteerAngle;
                }
                
            }

        }
        #endregion
    }
}

