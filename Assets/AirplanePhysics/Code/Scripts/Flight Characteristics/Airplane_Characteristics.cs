using UnityEngine;

namespace AirplanePhysics.Component
{
    public class Airplane_Characteristics : MonoBehaviour
    {

        #region VARIABLES
        private Rigidbody _rb;
        private float _startDrag;
        private float _startAngularDrag;

        [Header("Characteristics")]


        [Header("Forward Speed")]
        private Vector3 localVelocity;
        public float forwardSpeed;
        public float maxSpeed = 60.0f;
        private float normalizedSpeed;

        [Header("Lift Properties")]
        public float maxLiftForce = 800.0f;
        [SerializeField] private float liftForce;
        [SerializeField] private Vector3 finalLiftForce;
        [SerializeField] private float angleOfAttack;
        public AnimationCurve liftCurve = AnimationCurve.EaseInOut(0.0f, 0.0f, 1.0f, 1.0f);

        [Header("Drag Properties")]
        public float dragFactor = 0.01f;

        #endregion


        #region CONSTANTS
        const float mpsToMph = 2.23694f;
        #endregion

        #region CUSTOM METHODS
        public void InitCharacteristics(Rigidbody currRB)
        {
            //Basic Initialization
            _rb = currRB;
            _startDrag = _rb.linearDamping;
            _startAngularDrag = _rb.angularDamping;

        }

        public void UpdateCharacteristics() 
        {
            //Compute flight Characteristics
            if (_rb != null) 
            {
                ComputeForwardSpeed();
                ComputeLift();
                ComputeDrag();
                HandleRBTransform();
            }
            
        }

        
        private void ComputeForwardSpeed() 
        {
            localVelocity = transform.InverseTransformDirection(_rb.linearVelocity);

            forwardSpeed = Mathf.Max(0/0f,localVelocity.z);
            forwardSpeed = Mathf.Clamp(forwardSpeed, 0f, maxSpeed);

            normalizedSpeed = Mathf.InverseLerp(0.0f, maxSpeed, forwardSpeed);


        }

        private void ComputeLift()
        {

            //Compute angle of attack
            angleOfAttack = Vector3.Dot(_rb.linearVelocity.normalized,transform.forward);
            angleOfAttack *= angleOfAttack;

            //Compute lift force
            Vector3 liftDirection = transform.up; new Vector3(0,1,0); //Always perpendicular to the wings

            liftForce = liftCurve.Evaluate(normalizedSpeed) * maxLiftForce;
            finalLiftForce = liftDirection * liftForce * angleOfAttack;
           

            _rb.AddForce(finalLiftForce);
        }

        private void ComputeDrag()
        {
            float dragSpeed = forwardSpeed * dragFactor;
            float finalDragForce = _startDrag + dragSpeed;

            _rb.linearDamping = finalDragForce;
            _rb.angularDamping = _startAngularDrag * forwardSpeed;
        }


        private void HandleRBTransform()
        {
            if(_rb.linearVelocity.magnitude > 1.0f)
            {
                //Update velocity for extra stability
                Vector3 updatedVelocity = Vector3.Lerp(_rb.linearVelocity,transform.forward * forwardSpeed, forwardSpeed * angleOfAttack * Time.deltaTime);
                _rb.linearVelocity = updatedVelocity;

                //Update rotation
                Quaternion updatedRotation = Quaternion.Slerp(_rb.rotation, Quaternion.LookRotation(_rb.linearVelocity.normalized,transform.up),Time.deltaTime);
                _rb.MoveRotation(updatedRotation);

            }
        }

        #endregion


        private void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position,localVelocity, Color.blue);
            Debug.DrawRay(transform.localPosition, finalLiftForce, Color.green);

        }
    }
}

