using UnityEngine;
using UnityEditor;
using AirplanePhysics.AirplaneInputs;
using AirplanePhysics.Component;

namespace AirplanePhysics.Tools {
    public static class Airplane_SetupTools
    {
        public static void BuildDefaultAirplane(string airplaneName)
        {
            //Create root GameObject
            GameObject rootGO = new GameObject(airplaneName, typeof(Airplane_Controller), typeof(BaseAirplane_Input));
            //Create Center of Grvity and set parent
            GameObject cogGO = new GameObject("COG");
            cogGO.transform.SetParent(rootGO.transform, false);

            //Create base components or try to find them
            BaseAirplane_Input input = rootGO.GetComponent<BaseAirplane_Input>();
            Airplane_Controller controller = rootGO.GetComponent<Airplane_Controller>();
            Airplane_Characteristics characteristics = rootGO.GetComponent<Airplane_Characteristics>();
             

            //Airplane Setup
            if(controller != null)
            {
                //Assign core components
                controller.input = input;
                controller.characteristics = characteristics;
                controller.centerOfGravity = cogGO.transform;

                //Create Airplane GO strcuture
                GameObject GraphicsGRP = new GameObject("GraphicsGRP");
                GameObject CollidersGRP = new GameObject("CollidersGRP");
                GameObject ControlSurfacesGRP = new GameObject("ControlSurfacesGRP");

                GraphicsGRP.transform.SetParent(rootGO.transform, false);
                CollidersGRP.transform.SetParent(rootGO.transform, false);
                ControlSurfacesGRP.transform.SetParent(rootGO.transform, false);

                //Create First Engine
                GameObject EngineGO = new GameObject("Engine", typeof(Airplane_Engine));
                Airplane_Engine engine = EngineGO.GetComponent<Airplane_Engine>();
                controller.airplaneEngines.Add(engine);
                EngineGO.transform.SetParent(rootGO.transform, false);

                //Create Base Airplane with AssetDatabase
                GameObject defaultAirplane = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/AirplanePhysics/Art/Objects/Airplanes/Indie-Pixel_Airplane/IndiePixel_Airplane.fbx", typeof(GameObject));
                if(defaultAirplane != null)
                {
                    GameObject.Instantiate(defaultAirplane, GraphicsGRP.transform);
                }
            }

            //Select Airplane
            Selection.activeGameObject = rootGO;

            
        }
    }
}

