using UnityEngine;
using UnityEditor;


namespace AirplanePhysics.Tools
{
    public static class Airplane_Menus
    {
        [MenuItem("Airplane Tools/Create new Airplane")]
        //Sets up a plane, adds all the needed scripts to the current selected Empty GameObejct
        public static void CreateNewAirplane()
        {
            Airplane_SetupWindow.LaunchSetupWindow(); //BuildDefaultAirplane("New Airplane");
        }
    }
}

