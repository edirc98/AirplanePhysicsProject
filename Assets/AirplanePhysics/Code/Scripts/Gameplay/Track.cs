using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Track : MonoBehaviour
{
    #region VARIABLES
    [Header("Track Variables")]
    public List<Gate> Gates = new List<Gate>();

    private int currentGateID;
    #endregion

    #region UNITY BUILT-IN METHODS
    private void Awake()
    {
        FindGates();
        InitGates();
        currentGateID = 0;
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
                gate.onClearedGate.AddListener(SelectNextGate);

            }
        }
    }

    private void SelectNextGate()
    {

    }

    #endregion
}
