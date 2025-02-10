using UnityEngine;
using UnityEngine.Events;


namespace AirplanePhysics.Feature
{
    public class Airplane_Fuel : MonoBehaviour
    {
        #region VARIABLES
        [Header("Fuel Tank Properties")]
        [Tooltip("Fuel capacity in liters")]
        public float fuelCapacity = 100.0f; //In liters
        [Tooltip("Average fuel burn rate in liters per hour")]
        public float fuelBurnRate = 20.0f;  //Liters / hours

        [Header("Events")]
        public UnityEvent OnFullFuel = new UnityEvent();

        private float _currentFuel;
        private float _normalizedFuel;
        #endregion

        #region PROPERTIES
        public float CurrentFuel { get { return _currentFuel; } }
        public float NormalizedFuel { get { return _normalizedFuel; } }
        #endregion

        #region CUSTOM METHODS
        public void InitFuel()
        {
            _currentFuel = fuelCapacity;
        }
        public void UpdateFuelTank(float throttlePercent)
        {
            // Translate to liters per sec from liters per 
            float currentBurnRate = ((fuelBurnRate * throttlePercent) / 3600.0f) * Time.deltaTime;
            _currentFuel -= currentBurnRate;
            _currentFuel = Mathf.Clamp(_currentFuel, 0.0f, fuelCapacity);

            _normalizedFuel = _currentFuel / fuelCapacity; 

            Debug.Log("Consuming Fuel: " + currentBurnRate);
        }

        public void AddFuel(float fuelAmount)
        {
            _currentFuel += fuelAmount;
            _currentFuel = Mathf.Clamp(_currentFuel, 0.0f, fuelCapacity);

            if(_currentFuel >= fuelCapacity)
            {
                if(OnFullFuel != null)
                {
                    OnFullFuel.Invoke();
                }
            }
        }

        public void ResetFuel()
        {
            _currentFuel = fuelCapacity;
        }
        #endregion
    }
}

