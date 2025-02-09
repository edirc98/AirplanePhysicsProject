using UnityEngine;


namespace AirplanePhysics.UI
{
    public class AirplaneUI_Altimeter : MonoBehaviour, IAirplaneUI
    {

        #region VARIABLES
        [Header("Altimeter Properties")]
        public Airplane_Controller airplaneController;

        public RectTransform hundredsPointer;
        public RectTransform thousendsPointer;
        #endregion

        #region UNITY BUILT-IN METHODS
        #endregion

        #region CUSTOM METHODS
        #endregion

        #region INTERFACE METHODS
        public void HandleAirplaneUI()
        {
            if (airplaneController != null)
            {
                Debug.Log("Updating Altimeter");
                float currentAltitude = airplaneController.MSL;
                //Compute Thousends from 0 to 10
                float currentThousends = currentAltitude / 1000.0f;
                currentThousends = Mathf.Clamp(currentThousends, 0, 10); //Dial goes form 0 to 10

                //Compute Hundreds as the rest of the thousends
                float currentHundreds = currentAltitude - (Mathf.Floor(currentThousends) * 1000.0f);
                currentHundreds = Mathf.Clamp(currentHundreds,0.0f,1000.0f);

                //Transform thousends to rotation
                if (thousendsPointer != null) 
                {
                    float normalizedThousends = Mathf.InverseLerp(0.0f,10.0f, currentThousends);
                    float thousendsRotation = 360.0f * normalizedThousends;
                    thousendsPointer.rotation = Quaternion.Euler(0.0f,0.0f, -thousendsRotation);
                }

                //Transform hundreds to rotation
                if (hundredsPointer != null)
                {
                    float normalizedHundreds = Mathf.InverseLerp(0.0f,1000.0f, currentHundreds);
                    float hundredsRotation = 360.0f * normalizedHundreds;
                    hundredsPointer.rotation = Quaternion.Euler(0.0f,0.0f, -hundredsRotation);
                }
            }
        }
        #endregion
    }

}
