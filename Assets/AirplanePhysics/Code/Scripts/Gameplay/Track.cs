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

    // Update is called once per frame
    void Update()
    {

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
