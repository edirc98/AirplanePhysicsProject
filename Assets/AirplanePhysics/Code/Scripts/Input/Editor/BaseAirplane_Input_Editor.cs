using UnityEngine;
using UnityEditor;

namespace AirplanePhysics.AirplaneInputs
{
    [CustomEditor(typeof(BaseAirplane_Input))]
    public class BaseAirplane_Input_Editor : Editor
    {
        #region VARIABLES
        private BaseAirplane_Input targetInput;
        #endregion

        #region UNITY BUILT-IN METHODS
        private void OnEnable()
        {
            targetInput = (BaseAirplane_Input)target;
        }

        public override void OnInspectorGUI() 
        { 
            base.OnInspectorGUI(); //Adds the targets GUI base look

            //Custom Editor

            string DebugInfo = "";

            DebugInfo += "Pitch: " + targetInput.Pitch + "\n";
            DebugInfo += "Roll: " + targetInput.Roll + "\n";
            
            DebugInfo += "Yaw: " + targetInput.Yaw + "\n";
            DebugInfo += "Throttle: " + targetInput.Throttle + "\n";

            DebugInfo += "Brake: " + targetInput.Brake+ "\n";
            DebugInfo += "Flaps: " + targetInput.Flaps+ "\n";
            DebugInfo += "Camera Switch: " + targetInput.CameraSwitch+ "\n";

            EditorGUILayout.Space(); //GUILayout.Space(20);
            EditorGUILayout.TextArea(DebugInfo,GUILayout.Height(110));
            
            EditorGUILayout.Space();

            Repaint();
        }
        #endregion
    }
}

