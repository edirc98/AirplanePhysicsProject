using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Events;

public class Track : MonoBehaviour
{
    #region VARIABLES
    [Header("Track Variables")]
    public List<Gate> Gates = new List<Gate>();

    [Header("Track Events")]
    public UnityEvent OnCompletedTrack = new UnityEvent();

    private int currentGateID;
    #endregion

    #region UNITY BUILT-IN METHODS
    private void Awake()
    {
        FindGates();
        InitGates();
        currentGateID = 0;
        StartTrack();
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region CUSTOM METHODS

    private void FindGates()
    {
        Gates.Clear();
        Gates = GetComponentsInChildren<Gate>().ToList();
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
            Gates[currentGateID].ActivateGate();
        }
    }
    private void SelectNextGate()
    {
        currentGateID++;
        if(currentGateID == Gates.Count) //Last Gate, track finished
        {
            Debug.Log("Completed Track");
            if(OnCompletedTrack != null)
            {
                OnCompletedTrack.Invoke();
            }
            return;
        }
        Gates[currentGateID].ActivateGate();
    }

    #endregion
}
