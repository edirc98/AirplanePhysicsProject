using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace AirplanePhysics.UI
{
    public class AirplaneUI_Controller : MonoBehaviour
    {

        #region VARIABLES
        public List<IAirplaneUI> airplaneInstruments = new List<IAirplaneUI>();
        #endregion

        #region UNITY BUILT-IN METHODS
        void Start()
        {
            airplaneInstruments = transform.GetComponentsInChildren<IAirplaneUI>().ToList();
        }

        // Update is called once per frame
        void Update()
        {
            if (airplaneInstruments.Count > 0)
            {
                foreach (IAirplaneUI instrument in airplaneInstruments)
                {
                    instrument.HandleAirplaneUI();
                }
            }
        }
        #endregion

    }
}

