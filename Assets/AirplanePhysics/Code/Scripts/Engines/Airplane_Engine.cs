using UnityEngine;

namespace AirplanePhysics.Component
{
    public class Airplane_Engine : MonoBehaviour
    {

        #region VARIABLES
        [Header("Engine Properties")]
        public float maxForce = 200.0f;
        public float maxRPM = 2550.0f;

        [Header("Engine Power Curve")]
        public AnimationCurve powerCurve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);

        [Header("Propellers")]
        public Airplane_Propeller propeller;
        #endregion

        #region CUSTOM METHODS
        public Vector3 ComputeForce(float throttle) { 

            //Manage Throttle input value
            float throttleValue = Mathf.Clamp01(throttle);
            throttleValue = powerCurve.Evaluate(throttleValue);

            //RPMs compuitation && Propeller
            float currentRPM = throttleValue * maxRPM;
            if(propeller != null) { propeller.HandlePropeller(currentRPM); }

            //Apply force
            float finalForce = throttleValue * maxForce;
            Vector3 engineForce = transform.TransformDirection(transform.forward) * finalForce;
            return engineForce;
        }
        #endregion

    }
}

