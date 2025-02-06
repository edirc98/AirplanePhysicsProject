using AirplanePhysics.AirplaneInputs;
using AirplanePhysics.Component;
using IndiePixel.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AirplanePhysics
{
    [RequireComponent(typeof(Airplane_Characteristics))]
    public class Airplane_Controller : BaseRigidbody_Controller
    {
        #region VARIABLES
        [Header("Airplane Input")]
        public BaseAirplane_Input input;

        [Header("Base Airplane Properties")]
        public Transform centerOfGravity;
        [Tooltip("Airplane weight in Kg")] public float airplaneWeight = 800.0f;
        public Airplane_Characteristics characteristics;

        [Header("Engines")]
        public List<Airplane_Engine> airplane_Engines = new List<Airplane_Engine>();

        [Header("Wheels")]
        public List<Airplane_Wheel> airplane_Wheels = new List<Airplane_Wheel>();

        [Header("Control Surfaces")]
        public List<Airplane_ControlSurface> airplane_controlSurfaces = new List<Airplane_ControlSurface>();
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

                //Airplane characteristics
                characteristics = GetComponent<Airplane_Characteristics>();
                if (characteristics != null)
                {
                    characteristics.InitCharacteristics(_rb,input);
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
                HandleCharacteristics();
                HandleControlSurfaces();
                HandleWheels();
            }
        }

        private void HandleEngines()
        {
            if(airplane_Engines != null && airplane_Engines.Count > 0)
            {
                foreach (Airplane_Engine engine in airplane_Engines)
                {
                    //Engine force computation
                    _rb.AddForce( engine.ComputeForce(input.Throttle));
                }
            }
        }
        private void HandleCharacteristics()
        {
            if (characteristics != null) 
            { 
                characteristics.UpdateCharacteristics();
            } 
        }
        
        private void HandleWheels()
        {
            if(airplane_Wheels.Count > 0)
            {
                foreach(Airplane_Wheel wheel in airplane_Wheels)
                {
                    wheel.HandleWheel(input);
                } 
            }
        }

        private void HandleControlSurfaces()
        {
            if (airplane_controlSurfaces.Count > 0)
            {
                foreach(Airplane_ControlSurface controlSurface in airplane_controlSurfaces)
                {
                    controlSurface.HandleControlSurface(input);
                }
            }
        }

        #endregion
    }
}

