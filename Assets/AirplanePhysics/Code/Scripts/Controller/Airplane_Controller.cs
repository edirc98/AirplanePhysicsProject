using AirplanePhysics.AirplaneInputs;
using AirplanePhysics.Component;
using System;
using System.Collections.Generic;
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

        [Header("Engines")]
        public List<Airplane_Engine> airplaneEngines = new List<Airplane_Engine>();

        [Header("Wheels")]
        public List<Airplane_Wheel> airplane_Wheels = new List<Airplane_Wheel>();
        #endregion

        #region UNITY BUILT-IN METHODS
        public override void Start()
        {
            base.Start();

            //Apply mass to the RB
            if (_rb != null) 
            { 
                _rb.mass = airplaneWeight;
                if (centerOfGravity != null) 
                {
                    _rb.centerOfMass = centerOfGravity.localPosition;
                } 
            }

            //Wheels set up
            if(airplane_Wheels != null && airplane_Wheels.Count > 0)
            {
                foreach (Airplane_Wheel wheel in airplane_Wheels)
                {
                    wheel.InitWheel();
                }
            } 

        }
        #endregion

        #region CUSTOM METHODS
        protected override void HandlePhysics()
        {
            if(input != null)
            {
                HandleEngines();
                HandleAerodynamics();
                HandleSteering();
                HandleBrakes();
            }
        }

        private void HandleEngines()
        {
            if(airplaneEngines != null && airplaneEngines.Count > 0)
            {
                foreach (Airplane_Engine engine in airplaneEngines)
                {
                    //Engine force computation
                    _rb.AddForce( engine.ComputeForce(input.Throttle));
                }
            }
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

