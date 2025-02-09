using UnityEngine;


namespace AirplanePhysics.UI
{
    public class AirplaneUI_Altimeter : MonoBehaviour, IAirplaneUI
    {

        #region VARIABLES
        #endregion

        #region UNITY BUILT-IN METHODS
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }
        #endregion

        #region CUSTOM METHODS
        #endregion

        #region INTERFACE METHODS
        public void HandleAirplaneUI()
        {
            Debug.Log("Updating Altimeter");
        }
        #endregion
    }

}
