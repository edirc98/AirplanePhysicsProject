using AirplanePhysics.Component;
using UnityEngine;


namespace AirplanePhysics.UI 
{
    public class AirplaneUI_Attitude : MonoBehaviour, IAirplaneUI
    {
        #region VARIABLES
        [Header("Attitude Indicator Properties")]
        public Airplane_Controller airplane;
        public RectTransform backgroundRect; 
        public RectTransform arrowRect;
        #endregion

        #region INTERFACE METHODS
        public void HandleAirplaneUI()
        {
            if (airplane != null) 
            {
                //Roll Angle -> World Y against Right Plane vector
                float bankAngle =  Vector3.Dot(airplane.transform.right, Vector3.up) * Mathf.Rad2Deg;
                //Pithc Angle -> World Y against Forward Plane vector
                float pitchAngle = Vector3.Dot(airplane.transform.forward, Vector3.up) * Mathf.Rad2Deg;

                //Update UI Rect Rotation and Position
                if(backgroundRect != null)
                {
                    Quaternion BankingRotation = Quaternion.Euler(0f, 0f,bankAngle);
                    backgroundRect.transform.rotation = BankingRotation;

                    Vector3 wantedPosition = new Vector3 (0,pitchAngle,0);
                    backgroundRect.anchoredPosition = -wantedPosition;

                    if(arrowRect != null)
                    {
                        arrowRect.rotation = BankingRotation;
                    }
                }
            }
        }
        #endregion
    }
}

