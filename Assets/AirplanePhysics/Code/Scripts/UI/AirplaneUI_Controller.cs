using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace AirplanePhysics.UI
{
    public class AirplaneUI_Controller : MonoBehaviour
    {

        #region VARIABLES
        public List<IAirplaneUI> AirplaneInstruments = new List<IAirplaneUI>();
        #endregion

        #region UNITY BUILT-IN METHODS
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            AirplaneInstruments = transform.GetComponentsInChildren<IAirplaneUI>().ToList();
        }

        // Update is called once per frame
        void Update()
        {
            if (AirplaneInstruments.Count > 0)
            {
                foreach (IAirplaneUI instrument in AirplaneInstruments)
                {
                    instrument.HandleAirplaneUI();
                }
            }
        }
        #endregion

    }
}

