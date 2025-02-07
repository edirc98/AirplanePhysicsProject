using AirplanePhysics.AirplaneInputs;
using UnityEngine;

namespace AirplanePhysics
{
    public class Airplane_Audio : MonoBehaviour
    {
        #region VARIABLES
        [Header("Input")]
        public BaseAirplane_Input input;
        [Header("Airplane Audio Properties")]
        public AudioSource EngineIdleSource;
        public AudioSource EngineFullThrottleSource;
        public float MaxPitchValue = 1.5f;


        private float _finalVolumeValue;
        private float _finalPitchValue;
        #endregion

        #region UNITY BUILT-IN METHODS
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if(EngineFullThrottleSource != null) EngineFullThrottleSource.volume = 0.0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (input != null) 
            {
                HandleEngineAudio();
            }
        }


        #endregion

        #region CUSTOM METHODS
        protected virtual void HandleEngineAudio() 
        {
            _finalVolumeValue = Mathf.Lerp(0.0f, 1.0f, input.Throttle);
            _finalPitchValue = Mathf.Lerp(1.0f, MaxPitchValue, input.Throttle);

            if (EngineFullThrottleSource != null) {
                EngineFullThrottleSource.pitch = _finalPitchValue;
                EngineFullThrottleSource.volume = _finalVolumeValue;
            }
            
        }  
        #endregion
    }
}

