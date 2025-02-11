using UnityEngine;


namespace AirplanePhysics.UI
{
    public class AirplaneUI_ThrottleLever : MonoBehaviour, IAirplaneUI
    {
        #region VARIABLES
        [Header("Throttle Lever Properties")]
        public AirplaneInputs.BaseAirplane_Input input;
        public RectTransform leverInsertTransform;
        public RectTransform leverHandleTransform;
        public float handleSpeed = 2.0f;
        #endregion

        #region INTERFACE METHODS
        public void HandleAirplaneUI()
        {
            if(input != null && leverInsertTransform != null && leverHandleTransform != null)
            {
                float height = leverInsertTransform.rect.height;
                Vector2 wantedHandlePosition =  new Vector2 (0, height * input.Throttle);

                leverHandleTransform.anchoredPosition = Vector2.Lerp(leverHandleTransform.anchoredPosition, wantedHandlePosition, Time.deltaTime * handleSpeed);
            }
        }
        #endregion
    }
}

