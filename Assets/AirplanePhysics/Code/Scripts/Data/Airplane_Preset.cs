using UnityEngine;


namespace AirplanePhysics
{
    [CreateAssetMenu(menuName ="Airplane Physics/Create Aiplane Preset")]
    public class Airplane_Preset : ScriptableObject
    {
        #region CONTROLLER PROPERTIES
        [Header("Controller Properties")]
        public Vector3 AirplaneCenterOfGravityPosition;
        public float AirplaneWeight;
        #endregion

        #region CHARACTERISTICS PROPERTIES
        [Header("Characteristics Properties")]
        public float AirplaneMaxSpeed;
        public float AirplaneMaxLiftForce;
        public AnimationCurve AirplaneLiftCurve = AnimationCurve.EaseInOut(0.0f, 0.0f, 1.0f, 1.0f);
        public float AirplaneDragFactor;
        public float AirplaneFlapsDragFactor;
        [Header("Controls Properties")]
        public float AirplanePitchForce;
        public float AirplaneRollForce;
        public float AirplaneYawForce;
        public float AirplaneRigidBodyLerpSpeed;
        #endregion

        #region GROUND EFFECT PROPERTIES
        [Header("Ground Effect Variables")]
        public float GroundEffectMaxGroundDistance;
        public float GroundEffectLiftForce;
        public float GroundEffectMaxSpeedForGroundEffect;
        #endregion
    }
}

