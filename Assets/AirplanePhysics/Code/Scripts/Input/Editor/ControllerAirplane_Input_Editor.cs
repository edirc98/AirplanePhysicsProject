using AirplanePhysics.AirplaneInputs;
using UnityEditor;
using UnityEngine;

namespace AirplanePhysics.AirplaneInputs
{
    [CustomEditor(typeof(ControllerAirplane_Input))]
    public class ControllerAirplane_Input_Editor : Editor
    {
        #region VARIABLES
        private ControllerAirplane_Input targetInput;
        #endregion

        #region UNITY BUILT-IN METHODS
        private void OnEnable()
        {
            targetInput = (ControllerAirplane_Input)target;
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

            DebugInfo += "Brake: " + targetInput.Brake + "\n";
            DebugInfo += "Flaps: " + targetInput.Flaps + "\n";

            EditorGUILayout.Space(); //GUILayout.Space(20);
            EditorGUILayout.TextArea(DebugInfo, GUILayout.Height(100));

            EditorGUILayout.Space();

            Repaint();
        }
        #endregion
    }
}