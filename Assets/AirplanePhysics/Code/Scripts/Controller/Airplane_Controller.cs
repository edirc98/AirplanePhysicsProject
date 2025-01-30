using AirplanePhysics.AirplaneInputs;
using System;
using UnityEngine;

namespace AirplanePhysics
{
    public class Airplane_Controller : BaseRigidbody_Controller
    {
        #region VARIABLES
        [Header("Airplane Input")]
        public BaseAirplane_Input input;

        [Header("Base Airplane Properties")]
        public Transform centerOfGravity;
        [Tooltip("Airplane weight in Kg")] public float airplaneWeight = 800.0f;

        #endregion

        #region UNITY BUILT-IN METHODS
        public override void Start()
        {
            base.Start();
            if (_rb != null) 
            { 
                _rb.mass = airplaneWeight;
                if (centerOfGravity != null) 
                {
                    _rb.centerOfMass = centerOfGravity.localPosition;
                } 
            }
        }
        #endregion
        #region CUSTOM METHODS
        protected override void HandlePhysics()
        {
            HandleEngines();
            HandleAerodynamics();
            HandleSteering();
            HandleBrakes();
            //base.HandlePhysics();
        }

        private void HandleEngines()
        {

        }
        private void HandleAerodynamics()
        {

        }
        private void HandleSteering()
        {

        }
        private void HandleBrakes()
        {

        }

        #endregion
    }
}

