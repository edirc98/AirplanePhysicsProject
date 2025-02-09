using AirplanePhysics.Component;
using UnityEngine;



namespace AirplanePhysics.UI
{
    public class AirplaneUI_Tachometer : MonoBehaviour, IAirplaneUI
    {

        #region VARIABLES
        [Header("Tachometer Properties")]
        public Airplane_Engine airplane_Engine;
        public RectTransform rpmsPointer;
        public float pointerSpeed = 2.0f; 
        [Header("Tachometer Limits")]
        public float tachometerMaxRPMs = 3500.0f;
        public float tachometerMaxRotation = 312.0f;

        private float finalRotation; 
        #endregion

        #region UNITY BUILT-IN METHODS
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }
        #endregion

        #region CUSTOM METHODS
        #endregion

        #region INTEFACE METHODS
        public void HandleAirplaneUI()
        {
            if (airplane_Engine != null && rpmsPointer != null)
            {
                float normalizedRPMS = Mathf.InverseLerp(0.0f, tachometerMaxRPMs, airplane_Engine.RPMs);

                //Compute rotation
                float wantedRotation = tachometerMaxRotation * -normalizedRPMS;
                finalRotation = Mathf.Lerp(finalRotation, wantedRotation, Time.deltaTime * pointerSpeed); 
                rpmsPointer.rotation = Quaternion.Euler(0.0f,0.0f,finalRotation);
            }
        }
        #endregion
    }
}

