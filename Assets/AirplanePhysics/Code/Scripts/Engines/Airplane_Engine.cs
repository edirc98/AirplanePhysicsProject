using UnityEngine;
using AirplanePhysics.Feature;

namespace AirplanePhysics.Component
{
    [RequireComponent(typeof(Airplane_Fuel))]
    public class Airplane_Engine : MonoBehaviour
    {

        #region VARIABLES
        [Header("Engine Properties")]
        public float maxForce = 200.0f;
        public float idleRPM = 120.0f;
        public float maxRPM = 2550.0f;

        [Header("Engine Power Curve")]
        public AnimationCurve powerCurve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);

        [Header("Propellers")]
        public Airplane_Propeller propeller;

        private float _currentRPMs;

        [SerializeField] private Airplane_Fuel _fuelTank;
        #endregion

        #region PROPERTIES
        public float RPMs { get { return _currentRPMs; } set { _currentRPMs = value; } }

        #endregion

        #region UNITY BUILT-IN METHODS
        private void Start()
        {
            if(_fuelTank == null)
            {
                _fuelTank = GetComponent<Airplane_Fuel>();
                if (_fuelTank != null) _fuelTank.InitFuel();
            }
        }
        #endregion

        #region CUSTOM METHODS
        public Vector3 ComputeForce(float throttle) { 

            //Manage Throttle input value
            float throttleValue = Mathf.Clamp01(throttle);
            throttleValue = powerCurve.Evaluate(throttleValue);

            //RPMs compuitation && Propeller
            _currentRPMs = (throttleValue * maxRPM) + idleRPM;
            if(propeller != null) { propeller.HandlePropeller(_currentRPMs); }

            //Fuel Handling
            HandleFuel(throttle);

            //Apply force
            float finalForce = throttleValue * maxForce;
            //Vector3 engineForce = transform.TransformDirection(transform.forward) * finalForce;

            Vector3 engineForce = transform.forward * finalForce;

            return engineForce;

            
        }


        private void HandleFuel(float throttle)
        {
            //Handle fuel
            if (_fuelTank != null)
            {
                _fuelTank.UpdateFuelTank(throttle);

                if (_fuelTank.CurrentFuel <= 0)
                {
                    //ENGINE SHUT OFF-> TODO
                }
            }

            
        }
        #endregion

    }
}

