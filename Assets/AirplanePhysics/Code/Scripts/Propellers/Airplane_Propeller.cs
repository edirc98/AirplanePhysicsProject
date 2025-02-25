using UnityEngine;
using UnityEngine.Rendering;
using System.Collections.Generic;

namespace AirplanePhysics.Component
{
    public class Airplane_Propeller : MonoBehaviour
    {
        #region VARIABLES
        [Header("Propeller Properties")]
        public float minRPMs = 100.0f;
        public float minRPMsToSwap = 350.0f;
        public float minRPMsToTextureSwap = 1500.0f;

        [Header("Propeller Objects")]
        public GameObject propellerObejct;
        public List<GameObject> propellerBlurredObjects;

        [Header("Propeller Material Propeties")]
        public Material propellerBlurredMaterial;
        public Texture2D propellerblur1;
        public Texture2D propellerblur2;
        #endregion


        #region UNITY BUILT-IN METHODS
        private void Start()
        {
            propellerObejct.SetActive(true);
            SetActiveBlurredProps(false);
            //propellerBlurredObject.SetActive(false);
            
        }
        #endregion

        #region CUSTOM METHODS
        public void HandlePropeller(float currentRPM)
        {
            float degreesPerSec = ((currentRPM * 360) / 60) * Time.deltaTime;
            degreesPerSec = Mathf.Clamp(degreesPerSec, 0.0f, minRPMs);
            transform.Rotate(Vector3.up, degreesPerSec);

            //Handle Propeller Material swapping
            if(CheckAsignedObjects())
            {
                HandlePropellerSwapping(currentRPM);
            }
        }

        private void HandlePropellerSwapping(float currentRPM)
        {
            if (currentRPM > minRPMsToSwap)
            {
                SetActiveBlurredProps(true);
                //propellerBlurredObject.SetActive(true);
                propellerObejct.SetActive(false);
                if (currentRPM > minRPMsToTextureSwap)
                {
                    propellerBlurredMaterial.SetTexture("_MainTex", propellerblur2);
                }
                else 
                {
                    propellerBlurredMaterial.SetTexture("_MainTex", propellerblur1);
                }
            }
            else
            {
                SetActiveBlurredProps(false);
                //propellerBlurredObject.SetActive(false);
                propellerObejct.SetActive(true);
            }
        }

        private bool CheckAsignedObjects()
        {
            if(propellerObejct && propellerBlurredObjects.Count > 0 && propellerBlurredMaterial && propellerblur1 && propellerblur2)
            {
                return true;
            }
            else return false;
        }


        private void SetActiveBlurredProps(bool active)
        {
            foreach(GameObject prop in propellerBlurredObjects)
            {
                prop.SetActive(active);
            }
        }

        public void StopPropeller()
        {
            foreach (GameObject prop in propellerBlurredObjects)
            {
                if(prop.activeSelf == true)
                {
                    prop.SetActive(false);
                }
                if (propellerObejct.activeSelf == false)
                {
                    propellerObejct.SetActive(true);
                }
            }
        }

        #endregion

    }
}

