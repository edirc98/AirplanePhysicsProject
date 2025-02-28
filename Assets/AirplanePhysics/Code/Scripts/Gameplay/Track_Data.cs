using UnityEngine;


namespace AirplanePhysics
{
    [CreateAssetMenu(fileName = "New Track Data", menuName = "Airplane Physics/Track Data/New Track Data")]
    public class Track_Data : ScriptableObject
    {
        #region VARIABLES
        public float lastTrackTime;
        public float bestTrackTime;
        public float lastTrackScore;
        public float bestTrackScore; 
        #endregion

        #region CUSTOM METHODS

        public void SetTimes(float atime)
        {
            lastTrackTime = atime;
            if (bestTrackTime == 0)
            {
                bestTrackTime = lastTrackTime;
            }
            else if (lastTrackTime < bestTrackTime) 
            {
                bestTrackTime = lastTrackTime;
            }
        }

        public void SetScores(float aScore)
        {
            lastTrackScore = aScore;

            if (lastTrackScore > bestTrackScore) 
            {
                bestTrackScore = lastTrackScore;
            }
        }

        #endregion
    }
}

