using UnityEngine;

namespace AirplanePhysics
{
    public class Base_FollowCamera : MonoBehaviour
    {

        #region VARIABLES
        [Header("Follow Camera Properties")]
        public Transform followTarget;
        public float followDistance = 10.0f;
        public float heightDistance = 3.0f;
        public float cameraSmoothSpeed = 0.5f;

        private Vector3 smoothingVelocity;

        protected float originHeight; 
        #endregion

        #region UNITY BUILT-IN METHODS
        #endregion
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            originHeight = heightDistance;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if(followTarget != null)
            {
                HandleCamera();
            }
            
        }

        #region CUSTOM METHODS
        protected virtual void HandleCamera()
        {
            //Follow Camera
            Vector3 wantedPosition = followTarget.position + (-followTarget.forward * followDistance) + Vector3.up * heightDistance;
            Debug.DrawLine(followTarget.position, wantedPosition);

            //Camera position
            transform.position = Vector3.SmoothDamp(transform.position,wantedPosition,ref smoothingVelocity,cameraSmoothSpeed);
            //Camera rotation
            transform.LookAt(followTarget.position);    
        }
        #endregion
    }
}

