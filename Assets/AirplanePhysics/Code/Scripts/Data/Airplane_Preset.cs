using UnityEngine;


namespace AirplanePhysics
{
    [CreateAssetMenu(menuName ="Airplane Physics/Create Aiplane Preset")]
    public class Airplane_Preset : ScriptableObject
    {
        #region CONTROLLER PROPERTIES
        [Header("Controller Properties")]
        public Vector3 airplane_CoGPosition;
        public float aiplane_Weight; 
        #endregion
    }
}

