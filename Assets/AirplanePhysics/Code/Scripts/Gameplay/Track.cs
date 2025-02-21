using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Track : MonoBehaviour
{
    #region VARIABLES
    [Header("Track Variables")]
    public List<Gate> Gates = new List<Gate>();

    [Header("Track Events")]
    public UnityEvent OnCompletedTrack = new UnityEvent();

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
    #endregion

    #region UNITY BUILT-IN METHODS
    private void Start()
    {
        FindGates();
        InitGates();
        _currentGateID = 0;
        StartTrack();
    }

    private void Update()
    {
        UpdateTrackStats();
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
            Gates[_currentGateID].ActivateGate();
        }
    }
    private void SelectNextGate()
    {
        _currentGateID++;
        if(_currentGateID == Gates.Count) //Last Gate, track finished
        {
            if(OnCompletedTrack != null)
            {
                OnCompletedTrack.Invoke();
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
    #endregion
}
