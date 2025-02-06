using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;
using AirplanePhysics.Feature;
namespace AirplanePhysics.Component
{
    [CustomEditor(typeof(Airplane_Controller))]
    public class AirplaneController_Editor : Editor
    {
        
        #region VARIABLES
        private Airplane_Controller targetController;
        #endregion

        #region UNITY BUILT-IN METHODS
        
        void OnEnable()
        {
            targetController = (Airplane_Controller)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.Space(10.0f);
            
            if(GUILayout.Button("Get Airplane Components", GUILayout.Height(30.0f)))
            {
                //Clear lists
                targetController.airplane_Engines.Clear();
                targetController.airplane_Wheels.Clear();
                targetController.airplane_controlSurfaces.Clear();
                //Find All Components
                targetController.airplane_Engines = FindAllEngines();
                targetController.airplane_Wheels = FindAllWheels();
                targetController.airplane_controlSurfaces = FindAllControlSurfaces();
            }

            GUILayout.Space(5.0f);
            if(GUILayout.Button("Create Airplane Preset", GUILayout.Height(30.0f)))
            {
                string presetPath = EditorUtility.SaveFilePanel("Save Airplane Preset", "Assets", " New Airplane Preset", "asset");
                SaveAirplanePreset(presetPath);
            }

            GUILayout.Space(10.0f);
        }

        #endregion


        #region CUSTOM METHODS
        private List<Airplane_Engine> FindAllEngines()
        {
            Airplane_Engine[] engines = new Airplane_Engine[0];

            if(targetController != null)
            {
                engines = targetController.transform.GetComponentsInChildren<Airplane_Engine>(true);
            }

            return engines.ToList(); 
        }
        private List<Airplane_Wheel> FindAllWheels()
        {
            Airplane_Wheel[] wheels = new Airplane_Wheel[0];

            if (targetController != null)
            {
                wheels = targetController.transform.GetComponentsInChildren<Airplane_Wheel>(true);
            }

            return wheels.ToList();
        }
        private List<Airplane_ControlSurface> FindAllControlSurfaces()
        {
            Airplane_ControlSurface[] controlSurfaces = new Airplane_ControlSurface[0];

            if (targetController != null)
            {
                controlSurfaces = targetController.transform.GetComponentsInChildren<Airplane_ControlSurface>(true);
            }

            return controlSurfaces.ToList();
        }

        private void SaveAirplanePreset(string filePath)
        {
            if(targetController != null && !string.IsNullOrEmpty(filePath))
            {

                //Substract All the C/Users to /Assets
                string path = "Assets" + filePath.Substring(Application.dataPath.Length);

                //Create new preset object
                Airplane_Preset newPreset = CreateInstance<Airplane_Preset>();//new Airplane_Preset();
                newPreset.AirplaneWeight = targetController.airplaneWeight;
                if(targetController.centerOfGravity != null)
                {
                    newPreset.AirplaneCenterOfGravityPosition = targetController.centerOfGravity.localPosition;
                }

                if(targetController.characteristics != null)
                {
                    newPreset.AirplaneMaxSpeed = targetController.characteristics.maxSpeed; 
                    newPreset.AirplaneMaxLiftForce = targetController.characteristics.maxLiftForce; 
                    newPreset.AirplaneLiftCurve = targetController.characteristics.liftCurve; 
                    newPreset.AirplaneDragFactor = targetController.characteristics.dragFactor; 
                    newPreset.AirplaneFlapsDragFactor = targetController.characteristics.flapsDrag; 
                    newPreset.AirplanePitchForce = targetController.characteristics.pitchForce; 
                    newPreset.AirplaneRollForce = targetController.characteristics.rollForce; 
                    newPreset.AirplaneYawForce = targetController.characteristics.yawForce; 
                    newPreset.AirplaneRigidBodyLerpSpeed = targetController.characteristics.rbLerpSpeed; 
                }

                Airplane_GroundEffect groundEffectfeature = targetController.transform.GetComponent<Airplane_GroundEffect>();
                if(groundEffectfeature != null)
                {
                    newPreset.GroundEffectMaxGroundDistance = groundEffectfeature.maxGroundDistance;
                    newPreset.GroundEffectMaxSpeedForGroundEffect = groundEffectfeature.maxSpeedForGroundEffect;
                    newPreset.GroundEffectLiftForce = groundEffectfeature.liftForce; 
                }

                //Create preset Asset
                AssetDatabase.CreateAsset(newPreset, path);
            }
        }
        #endregion
    }
}

