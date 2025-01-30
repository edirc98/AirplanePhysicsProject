using UnityEngine;
using UnityEditor;


namespace AirplanePhysics
{
    public static class Airplane_Menus
    {
        [MenuItem("Airplane Tools/Create new Airplane")]
        //Sets up a plane, adds all the needed scripts to the current selected Empty GameObejct
        public static void CreateNewAirpalne() {
            Debug.Log("Creating New Airplane");
            GameObject currentSelected = Selection.activeGameObject;
            if (currentSelected != null) 
            {
                //Add airplene controller script
                Airplane_Controller currentController = currentSelected.AddComponent<Airplane_Controller>();

                //Create a new empty game object that will be the COG and asign it as child of the current selected
                GameObject currentCOG = new GameObject("COG");
                currentCOG.transform.SetParent(currentSelected.transform);

                //Asign the created COG to the variable in the airplane controller
                currentController.centerOfGravity = currentCOG.transform;
            }
        }
    }
}

