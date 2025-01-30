using UnityEngine;


namespace AirplanePhysics
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent (typeof(AudioSource))]
    public class BaseRigidbody_Controller : MonoBehaviour
    {

        #region VARIABLES
        protected Rigidbody _rb;
        protected AudioSource _audioSource;
        #endregion

        #region UNITY BUILT-IN METHODS
        public virtual void Start()
        {
            _rb = GetComponent<Rigidbody>();

            _audioSource = GetComponent<AudioSource>();
            if (_audioSource != null) { _audioSource.playOnAwake = false; }
        }

        void FixedUpdate()
        {
            if (_rb != null) 
            {
                HandlePhysics();
            }
        }
        #endregion

        #region CUSTOM METHODS
        protected virtual void HandlePhysics(){}
        #endregion
    }
}
