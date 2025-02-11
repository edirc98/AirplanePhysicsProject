using UnityEngine;

namespace AirplanePhysics.UI
{
    public class AirplaneUI_FlapsLever : MonoBehaviour, IAirplaneUI
    {
        #region VARIABLES
        [Header("Flaps Lever Properties")]
        public AirplaneInputs.BaseAirplane_Input input;
        public RectTransform leverInsertTransform;
        public RectTransform leverHandleTransform;
        public float handleSpeed = 2.0f;
        #endregion


        #region INTERFACE METHODS

        public void HandleAirplaneUI()
        {
            if (input != null && leverInsertTransform != null && leverHandleTransform != null)
            {
                float height = leverInsertTransform.rect.height;

                
                Vector2 wantedHandlePosition = new Vector2(0, height * input.FlapsNormalized);

                leverHandleTransform.anchoredPosition = Vector2.Lerp(leverHandleTransform.anchoredPosition, -wantedHandlePosition, Time.deltaTime * handleSpeed);
            }
        }

        #endregion
    }
}

