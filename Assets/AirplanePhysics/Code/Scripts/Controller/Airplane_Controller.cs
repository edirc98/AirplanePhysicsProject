using AirplanePhysics.AirplaneInputs;
using AirplanePhysics.Component;
using System;
using System.Collections.Generic;
using UnityEngine;
using AirplanePhysics.Feature;

namespace AirplanePhysics
{

    public enum AIRPLANE_STATE
    {
        LANDED, 
        GROUNDED,
        FLYING, 
        CRASHED
    }

    [RequireComponent(typeof(Airplane_Characteristics))]
    public class Airplane_Controller : BaseRigidbody_Controller
    {
        #region VARIABLES

        [Header("Airplane Preset")]
        public Airplane_Preset preset; 

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

        [Header("Features")]
        public Airplane_GroundEffect groundEffectFeature;

        private float _currentMSL; // MEAN SEA LEVEL, Altitude from 0
        private float _currentAGL; //ABOVE GROUND LEVEL, Altitude to closest surface

        [SerializeField] private AIRPLANE_STATE _airplaneState = AIRPLANE_STATE.LANDED;

        [SerializeField] private bool isGrounded = false; 
        [SerializeField] private bool isLanded = false;
        [SerializeField] private bool isFlying = false;
        [SerializeField] private bool isCrashed = false;

        #endregion

        #region PROPETIES
        public float MSL { get { return _currentMSL; } }
        public float AGL { get { return _currentAGL; } }
        #endregion

        #region UNITY BUILT-IN METHODS
        public override void Start()
        {

            try
            {
                groundEffectFeature = GetComponent<Airplane_GroundEffect>();
            }
            catch(Exception e)
            {
                Debug.Log("No gorund effect feature found: " + e.Message);
            }
            GetPresetInfo();
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

            //Check if the plane is grounded
            InvokeRepeating("CkeckPlaneState", 2.0f, 1.5f);
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
                HandleAltitude();
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
        private void HandleAltitude()
        {
            _currentMSL = transform.position.y;

            RaycastHit rayHit; 
            if(Physics.Raycast(transform.position, Vector3.down, out rayHit))
            {
                _currentAGL = transform.position.y - rayHit.point.y;
            }
        }
        private void GetPresetInfo()
        {
            if(preset != null)
            {
                airplaneWeight = preset.AirplaneWeight;
                centerOfGravity.localPosition = preset.AirplaneCenterOfGravityPosition;

                if(characteristics != null)
                {
                    characteristics.maxSpeed = preset.AirplaneMaxSpeed;
                    characteristics.maxLiftForce = preset.AirplaneMaxLiftForce; 
                    characteristics.liftCurve = preset.AirplaneLiftCurve; 
                    characteristics.dragFactor = preset.AirplaneDragFactor; 
                    characteristics.flapsDrag = preset.AirplaneFlapsDragFactor; 
                    characteristics.pitchForce = preset.AirplanePitchForce; 
                    characteristics.rollForce = preset.AirplaneRollForce; 
                    characteristics.yawForce = preset.AirplaneYawForce; 
                    characteristics.rbLerpSpeed = preset.AirplaneRigidBodyLerpSpeed; 
                }
                if(groundEffectFeature != null)
                {
                    groundEffectFeature.maxGroundDistance = preset.GroundEffectMaxGroundDistance;
                    groundEffectFeature.liftForce = preset.GroundEffectLiftForce;
                    groundEffectFeature.maxSpeedForGroundEffect = preset.GroundEffectMaxSpeedForGroundEffect; 
                }
            }
        }

        private void CkeckPlaneState()
        {
            if (airplane_Wheels.Count > 0) 
            {
                int groundedCount = 0;
                foreach (Airplane_Wheel wheel in airplane_Wheels) 
                {
                    if (wheel.IsGrounded) { groundedCount++; }
                }

                if (groundedCount >= airplane_Wheels.Count - 1) //At least all wheels - 1 to consider the plane grounded
                {
                    if (_rb.linearVelocity.magnitude < 2.0f)
                    {
                        isLanded = true;
                        isGrounded = true;
                        isCrashed = false;
                        isFlying = false;
                        _airplaneState = AIRPLANE_STATE.LANDED;
                    }
                    else
                    {
                        isLanded = false;
                        isGrounded = true;
                        isCrashed = false;
                        isFlying = false;
                        _airplaneState = AIRPLANE_STATE.GROUNDED;
                    }
                }
                else if(groundedCount == 0 && _rb.linearVelocity.magnitude < 2.0f)
                {
                    
                    isLanded = false;
                    isGrounded = false;
                    isFlying = false;
                    isCrashed = true;
                    _airplaneState = AIRPLANE_STATE.CRASHED;
                }
                else
                {
                    isLanded = false;
                    isGrounded = false;
                    isCrashed = false;
                    isFlying = true;
                    _airplaneState = AIRPLANE_STATE.FLYING;
                }
            }
        }
        #endregion
    }
}

