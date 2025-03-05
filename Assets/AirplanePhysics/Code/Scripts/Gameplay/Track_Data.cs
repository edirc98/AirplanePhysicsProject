using UnityEngine;


namespace AirplanePhysics
{
    [CreateAssetMenu(fileName = "New Track Data", menuName = "Airplane Physics/Track Data/New Track Data")]
    public class Track_Data : ScriptableObject
    {
        #region VARIABLES
        private float _lastTrackTime;
        private float _bestTrackTime;
        private float _lastTrackScore;
        private float _bestTrackScore;
        #endregion

        #region PROPERTIES
        public float LastTrackTime { get { return _lastTrackTime; } }
        public float BestTrackTime { get { return _bestTrackTime; } }
        public float LastTrackScore { get { return _lastTrackScore; } }
        public float BestTrackScore { get { return _bestTrackScore; } }

        #endregion

        #region CUSTOM METHODS

        public void SetTimes(float atime)
        {
            _lastTrackTime = atime;
            if (_bestTrackTime == 0)
            {
                _bestTrackTime = _lastTrackTime;
            }
            else if (_lastTrackTime < _bestTrackTime) 
            {
                _bestTrackTime = _lastTrackTime;
            }
        }

        public void SetScores(float aScore)
        {
            _lastTrackScore = aScore;

            if (_lastTrackScore > _bestTrackScore) 
            {
                _bestTrackScore = _lastTrackScore;
            }
        }

        #endregion
    }
}

