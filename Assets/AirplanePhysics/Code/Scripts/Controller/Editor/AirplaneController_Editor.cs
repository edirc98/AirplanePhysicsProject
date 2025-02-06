using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;


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
            
            if(GUILayout.Button("Get Airplane Components", GUILayout.Height(25)))
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
        #endregion
    }
}

