using UnityEngine;
using AirplanePhysics.Feature;

namespace AirplanePhysics.UI
{
    public class AirplaneUI_FuelGauge : MonoBehaviour, IAirplaneUI
    {

        #region VARIABLES
        [Header("Fuel Gauge Properties")]
        public Airplane_Fuel fuelTank;
        public RectTransform fuelPointer;

        [Header("Pointer Properties")]
        public Vector2 minMaxPointerRotation = new Vector2(-90.0f, 90.0f);
        #endregion

        #region INTERFACE METHODS
        public void HandleAirplaneUI()
        {
            if(fuelTank != null && fuelPointer != null)
            {
                float wantedRotation = Mathf.Lerp(minMaxPointerRotation.x, minMaxPointerRotation.y, fuelTank.NormalizedFuel);
                fuelPointer.rotation = Quaternion.Euler(0.0f, 0.0f, -wantedRotation); 
            }
        }
        #endregion

    }
}

