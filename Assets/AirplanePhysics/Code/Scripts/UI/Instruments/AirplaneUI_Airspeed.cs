using AirplanePhysics.Component;
using UnityEngine;


namespace AirplanePhysics.UI
{
    public class AirplaneUI_Airspeed : MonoBehaviour,IAirplaneUI
{
        #region VARIABLES
        [Header("Airspeed Indicator Properties")]
        public Airplane_Characteristics characteristics;
        public RectTransform pointer;
        public float maxIndicatedKnots = 210.0f;
        #endregion


        #region CONSTANTS
        public const float mpsToKnots = 1.94384f;
        #endregion
        #region INTERFACE METHODS
        public void HandleAirplaneUI()
        {
            if (characteristics != null && pointer != null) 
            {
                float currentKnots = characteristics.MPS * mpsToKnots;
                
                float normalizedKnots = Mathf.InverseLerp(0.0f,maxIndicatedKnots, currentKnots);
                float wantedRotation = 360.0f * normalizedKnots;

                pointer.rotation = Quaternion.Euler(0.0f,0.0f,-wantedRotation);
            }
        }
        #endregion

    }
}

