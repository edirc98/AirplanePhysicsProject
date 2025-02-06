using UnityEngine;


namespace AirplanePhysics.Feature
{
    public class Airplane_GroundEffect : MonoBehaviour
    {
        #region VARIABLES
        [Header("Ground Effect Variables")]
        public float maxGroundDistance = 3.0f;
        public float liftForce = 100.0f;
        public float maxSpeedForGroundEffect = 20.0f;

        private Rigidbody _rb;
        #endregion

        #region UNITY BUILT-IN METHODS
        #endregion
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if(_rb != null)
            {
                HandleGroundEffect();
            }
        }

        #region CUSOTM METHODS
        protected virtual void HandleGroundEffect()
        {
            RaycastHit rayHit;
            if(Physics.Raycast(transform.position,Vector3.down,out rayHit)){
                if(rayHit.transform.tag == "Ground" && rayHit.distance < maxGroundDistance)
                {
                    //Add ground effect lift
                    float currentSpeed = _rb.linearVelocity.magnitude;
                    float normalizedSpeed = currentSpeed / maxSpeedForGroundEffect;
                    normalizedSpeed = Mathf.Clamp01(normalizedSpeed);
                    float currentDistance = maxGroundDistance - rayHit.distance; // The lower the distance the higher ground effect force
                    float finalGorundEffectForce = liftForce * currentDistance * normalizedSpeed;
                    _rb.AddForce(Vector3.up * finalGorundEffectForce);
                }
            }
        }
        #endregion
    }
}

