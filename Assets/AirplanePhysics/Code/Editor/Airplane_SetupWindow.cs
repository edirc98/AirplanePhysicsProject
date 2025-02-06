using UnityEngine;
using UnityEditor;


namespace AirplanePhysics.Tools
{
    public class Airplane_SetupWindow : EditorWindow
    {
        #region VARIABLES
        private string airplaneName;
        private static Airplane_SetupWindow window;
        #endregion
        #region UNITY BUILT-IN METHODS
        public static void LaunchSetupWindow()
        {
            
            window = (Airplane_SetupWindow)GetWindow(typeof(Airplane_SetupWindow), false, "Airplane Setup");
            window.Show();
        }

        private void OnGUI()
        {
            airplaneName = EditorGUILayout.TextField("Airplane name: ", airplaneName);
            if(GUILayout.Button("Create new Airplane"))
            {

                Airplane_SetupTools.BuildDefaultAirplane(airplaneName);
                window.Close();
            }
        }
        #endregion
    }
}

