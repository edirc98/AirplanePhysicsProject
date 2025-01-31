using UnityEngine;
using UnityEngine.Rendering;

namespace AirplanePhysics.Component
{
    public class Airplane_Propeller : MonoBehaviour
    {
        #region VARIABLES
        [Header("Propeller Properties")]
        public float minRPMsToSwap = 300.0f;
        public float minRPMsToTextureSwap = 1500.0f;

        [Header("Propeller Objects")]
        public GameObject propellerObejct;
        public GameObject propellerBlurredObject;

        [Header("Propeller Material Propeties")]
        public Material propellerBlurredMaterial;
        public Texture2D propellerblur1;
        public Texture2D propellerblur2;
        #endregion


        #region UNITY BUILT-IN METHODS
        private void Start()
        {
            propellerObejct.SetActive(true);
            propellerBlurredObject.SetActive(false);
            
        }
        #endregion

        #region CUSTOM METHODS
        public void HandlePropeller(float currentRPM)
        {
            float degreesPerSec = ((currentRPM * 360) / 60) * Time.deltaTime;
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
                propellerBlurredObject.SetActive(true);
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
                propellerBlurredObject.SetActive(false);
                propellerObejct.SetActive(true);
            }
        }

        private bool CheckAsignedObjects()
        {
            if(propellerObejct && propellerBlurredObject && propellerBlurredMaterial && propellerblur1 && propellerblur2)
            {
                return true;
            }
            else return false;
        }

        #endregion

    }
}

