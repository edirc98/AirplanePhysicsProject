using AirplanePhysics.AirplaneInputs;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.Rendering;

namespace AirplanePhysics.Component
{
    public class Airplane_Characteristics : MonoBehaviour
    {

        #region VARIABLES
        private Rigidbody _rb;
        private BaseAirplane_Input _input;
        private float _startDrag;
        private float _startAngularDrag;

 
        [Header("Speed Properties")]
        public float maxSpeed = 80.0f;
        [SerializeField] private float forwardSpeed;
        private Vector3 localVelocity;
        private Vector3 localZVelocity;
        
        private float normalizedSpeed;
        public float MPS { get { return forwardSpeed; } }

        [Header("Lift Properties")]
        public float maxLiftForce = 800.0f;
        public AnimationCurve liftCurve = AnimationCurve.EaseInOut(0.0f, 0.0f, 1.0f, 1.0f);
        public float flapsLiftForce = 100.0f; 

        [SerializeField] private float liftForce;
        [SerializeField] private Vector3 finalLiftForce;
        [SerializeField] private float angleOfAttack;
        

        [Header("Drag Properties")]
        public float dragFactor = 0.01f;
        public float flapsDrag = 0.005f;

        [Header("Control Properties")]
        public float pitchForce = 1000.0f;
        public float rollForce = 1000.0f;
        public float yawForce = 1000.0f;
        public float rbLerpSpeed = 0.03f;
        public AnimationCurve controlSurfaceEfficiency = AnimationCurve.EaseInOut(0.0f, 0.0f, 1.0f, 1.0f);
        private float csEfficiency;

        [Header("Pitch")]
        [SerializeField] private float pitchAngle;
        [Header("Roll")]
        [SerializeField] private float rollAngle;
        [Header("Roll")]
        [SerializeField] private float yawAngle;

        #endregion

        #region CONSTANTS
        const float mpsToMph = 2.23694f;
        #endregion

        #region CUSTOM METHODS
        public void InitCharacteristics(Rigidbody currRB, BaseAirplane_Input currInput)
        {
            //Basic Initialization
            _rb = currRB;
            _input = currInput;
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

                //Picth, Roll and Yaw movement
                HandleControlSurfaceEfficiency();
                HandlePitch();
                HandleRoll();
                HandleYaw();
                HandleBanking();

                HandleRBTransform();
            }
            
        }

        
        private void ComputeForwardSpeed() 
        {
            localVelocity = transform.InverseTransformDirection(_rb.linearVelocity);
            localZVelocity = new Vector3(0,0,localVelocity.z);

            forwardSpeed = Mathf.Max(0.0f,localVelocity.z);
            forwardSpeed = Mathf.Clamp(forwardSpeed, 0f, maxSpeed);

            normalizedSpeed = Mathf.InverseLerp(0.0f, maxSpeed, forwardSpeed);

        }

        private void ComputeLift()
        {

            //Compute angle of attack
            angleOfAttack = Vector3.Dot(_rb.linearVelocity.normalized,transform.forward);
            angleOfAttack *= angleOfAttack;

            //Compute lift force
            Vector3 liftDirection = transform.up; //new Vector3(0,1,0); //Always perpendicular to the wings

            //Compute Flaps Lift
            float finalFlapsLiftForce = flapsLiftForce * _input.FlapsNormalized;

            liftForce = liftCurve.Evaluate(normalizedSpeed) * maxLiftForce;
            finalLiftForce = liftDirection * (flapsLiftForce + liftForce) * angleOfAttack;
           
            _rb.AddForce(finalLiftForce);
        }

        private void ComputeDrag()
        {
            float dragSpeed = forwardSpeed * dragFactor;

            //Add flaps drag

            float addedflapsDrag =  _input.Flaps * flapsDrag;

            //Combined Drag
            float finalDragForce = _startDrag + dragSpeed + addedflapsDrag;

            _rb.linearDamping = finalDragForce;
            _rb.angularDamping = _startAngularDrag * forwardSpeed;
        }


        private void HandleControlSurfaceEfficiency()
        {
            csEfficiency = controlSurfaceEfficiency.Evaluate(normalizedSpeed);
        }

        private void HandlePitch()
        {
            Vector3 flatForward = new Vector3(transform.forward.x,0,transform.forward.z).normalized;
            
            pitchAngle = Vector3.Angle(transform.forward, flatForward);

            //Compute torque based on pitch
            Vector3 pitchTorque = -_input.Pitch * pitchForce * transform.right * csEfficiency;

            _rb.AddTorque(pitchTorque);

        }

        private void HandleRoll()
        {
            Vector3 flatRight = new Vector3(transform.right.x,0,transform.right.z).normalized;
            rollAngle = Vector3.SignedAngle(transform.right, flatRight, transform.forward);

            //Compute torque based on roll
            Vector3 rollTorque = -_input.Roll * rollForce * transform.forward * csEfficiency;
            _rb.AddTorque(rollTorque);
        }

        private void HandleYaw()
        {
            Vector3 yawTorque = _input.Yaw * yawForce * transform.up * csEfficiency;
            _rb.AddTorque(yawTorque);
        }

        private void HandleBanking()
        {
            float bankSide = Mathf.InverseLerp(-90.0f, 90.0f, rollAngle); //Bank side goes form 0 to 1
            float bankAmount = Mathf.Lerp(-1.0f, 1.0f, bankSide); // Now goes from -1 to 1

            Vector3 bankTorque = bankAmount * rollForce * transform.up;
            _rb.AddTorque(bankTorque);
        }

        private void HandleRBTransform()
        {
            if(_rb.linearVelocity.magnitude > 1.0f)
            {
                //Update velocity for extra stability
                Vector3 updatedVelocity = Vector3.Lerp(_rb.linearVelocity,transform.forward * forwardSpeed, forwardSpeed * angleOfAttack * Time.deltaTime * rbLerpSpeed);
                _rb.linearVelocity = updatedVelocity;

                //Update rotation
                Quaternion updatedRotation = Quaternion.Slerp(_rb.rotation, Quaternion.LookRotation(_rb.linearVelocity.normalized,transform.up),Time.deltaTime * rbLerpSpeed);
                _rb.MoveRotation(updatedRotation);

            }
        }

        

        #endregion


        private void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position,localZVelocity, Color.blue);
            Debug.DrawRay(transform.localPosition, finalLiftForce, Color.green);
        }
    }
}

