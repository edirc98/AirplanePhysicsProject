using UnityEngine;


namespace AirplanePhysics.Component
{
    [RequireComponent(typeof(WheelCollider))]
    public class Airplane_Wheel : MonoBehaviour
    {
        #region VARIABLES
        private WheelCollider _wheelCollider;
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
        #endregion
    }
}

