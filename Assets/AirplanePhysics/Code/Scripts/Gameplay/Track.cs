using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Events;
using UnityEngine.Rendering;
using AirplanePhysics;

public class Track : MonoBehaviour
{
    #region VARIABLES
    [Header("Track Variables")]
    public Track_Data trackData;
    public List<Gate> Gates = new List<Gate>();

    [Header("Track Events")]
    public UnityEvent OnCompletedTrack = new UnityEvent();

    private bool _trackStarted = false;
    public bool TrackStarted { get { return _trackStarted; } set { _trackStarted = value; } }

    private int _currentGateID;
    public int CurrentGateID {  get { return _currentGateID; } }

    private int _totalGates; 
    public int TotalGates {  get { return _totalGates; } }

    private float _startTime;
    private int _currentTime;

    private int _currentMins; 
    public int CurrentMinutes { get { return _currentMins; } }
    private int _currentSecs;
    public int CurrentSeconds { get { return _currentSecs; } }

    private int _currentScore; 
    public int CurrentScore { get { return _currentScore; } }
    #endregion

    #region UNITY BUILT-IN METHODS
    private void Start()
    {
        FindGates();
        InitGates();
        _currentGateID = 0;
    }

    private void Update()
    {
        if (_trackStarted)
        {
            UpdateTrackStats();
        }
    }

    private void OnDrawGizmos()
    {
        //Visualize the track
        FindGates();
        if (Gates.Count > 0) 
        {
            for (int i = 0; i < Gates.Count; i++) 
            {
                if(i+1 == Gates.Count) //Last Gate of the list
                {
                    break;
                }
                else
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(Gates[i].transform.position, Gates[i + 1].transform.position);
                }
            }
        }

    }

    #endregion

    #region CUSTOM METHODS

    private void FindGates()
    {
        Gates.Clear();
        Gates = GetComponentsInChildren<Gate>().ToList();
        _totalGates = Gates.Count;
    }
    private void InitGates()
    {
        if (Gates.Count > 0) 
        {
            foreach (Gate gate in Gates) 
            {
                gate.DeactivateGate();
                gate.OnClearedGate.AddListener(SelectNextGate);

            }
        }
    }
    public void StartTrack()
    {
        if (Gates.Count > 0)
        {
            _startTime = Time.time;
            _currentScore = 0;
            Gates[_currentGateID].ActivateGate();
            _trackStarted = true; 
        }
    }
    private void SelectNextGate(float distPercent)
    {
        
        int gateScore = Mathf.RoundToInt(100.0f * distPercent);
        gateScore = Mathf.Clamp(gateScore, 0, 100);
        Debug.Log("GateScore: " + gateScore);
        _currentScore += gateScore;

        _currentGateID++;
        if(_currentGateID == Gates.Count) //Last Gate, track finished
        {
            if(OnCompletedTrack != null)
            {
                OnCompletedTrack.Invoke();
                _trackStarted = false;
            }
            return;
        }
        Gates[_currentGateID].ActivateGate();
    }

    private void UpdateTrackStats()
    {
        _currentTime = (int)(Time.time - _startTime);
        _currentMins = (_currentTime / 60);
        _currentSecs = (_currentTime -(_currentMins * 60));
    }

    public void SaveTrackData()
    {
        if (trackData != null) 
        {
            trackData.SetTimes(_currentTime);
            trackData.SetScores(_currentScore);
        }
    }
    #endregion
}
