using UnityEngine;

namespace AirplanePhysics.Component
{
    public class Airplane_Camera : Base_FollowCamera
    {
        #region VARIABLES
        [Header("Airplane Camera Properties")]
        public float minHeightFromGround = 6.0f;
        #endregion
        #region CUSTOM METHODS
        protected override void HandleCamera()
        {
            //Airplane Follow Camera
            RaycastHit rayhit;
            if (Physics.Raycast(transform.position, Vector3.down,out rayhit)) 
            {
                if (rayhit.distance < minHeightFromGround && rayhit.transform.tag == "Ground") 
                {
                    float wantedHeight = originHeight + (minHeightFromGround - rayhit.distance);
                    heightDistance = wantedHeight;
                }
            }

            base.HandleCamera();
        }
        #endregion
    }
}

