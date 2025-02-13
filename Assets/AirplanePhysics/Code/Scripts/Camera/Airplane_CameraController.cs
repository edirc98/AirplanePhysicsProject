using AirplanePhysics.AirplaneInputs;
using System.Collections.Generic;
using UnityEngine;

namespace AirplanePhysics
{
    public class Airplane_CameraController : MonoBehaviour
    {

        #region VARIABLES
        [Header("Camera controller Properties")]
        public BaseAirplane_Input input;
        public int StartCameraIndex = 0;
        public List<Camera> AirplaneCameras = new List<Camera>();

        private int _cameraIndex = 0;
        #endregion

        #region UNITY BUILT-IN METHODS
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

            //Enable the selectes start camera
            if(StartCameraIndex >=0 && StartCameraIndex < AirplaneCameras.Count) 
            {
                DisableAllCameras();
                AirplaneCameras[StartCameraIndex].enabled = true;
                AirplaneCameras[StartCameraIndex].GetComponent<AudioListener>().enabled = true;

            }
        }

        // Update is called once per frame
        void Update()
        {
            if (input != null)
            {
                if (input.CameraSwitch)
                {
                    SwitchCamera();
                    input.CameraSwitch = false;
                }
            }
        }
        #endregion


        #region CUSTOM METHODS
        protected virtual void SwitchCamera()
        {
            if (AirplaneCameras.Count > 0) 
            {
                DisableAllCameras();
                _cameraIndex++;
                //Make sure index do not goes out of bounds
                if(_cameraIndex >= AirplaneCameras.Count)
                {
                    _cameraIndex = 0;
                }

                AirplaneCameras[_cameraIndex].enabled = true;
                AirplaneCameras[_cameraIndex].GetComponent<AudioListener>().enabled = true;
            }
        }

        private void DisableAllCameras()
        {
            if(AirplaneCameras.Count > 0)
            {
                foreach (Camera cam in AirplaneCameras) { 
                    cam.enabled = false;
                    cam.GetComponent<AudioListener>().enabled = false;
                }
                
            }
        }
        #endregion
    }
}

