using AirplanePhysics;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Track_Manager : MonoBehaviour
{
    #region VARIABLES
    [Header("Track Manager Properties")]
    public List<Track> Tracks = new List<Track>();

    public Airplane_Controller currentAirplane;
    #endregion

    #region UNITY BUILT-IN METHODS
    private void Awake()
    {

    }
    void Start()
    {
        //currentAirplane = GameObject.FindGameObjectWithTag("Player").GetComponent<Airplane_Controller>();

        FindTracks();
        InitTracks();

        StartTrack(1);
    }

    void Update()
    {

    }
    #endregion

    #region CUSTOM METHODS
    private void FindTracks()
    {
        Tracks.Clear();
        Tracks = GetComponentsInChildren<Track>(true).ToList();
    }

    private void InitTracks()
    {
        if (Tracks.Count > 0)
        {
            foreach (Track track in Tracks)
            {
                track.OnCompletedTrack.AddListener(CompletedTrack);
            }
        }
    }

    private void CompletedTrack()
    {
        Debug.Log("Track Manager: Track Completed");
    }

    public void StartTrack(int trackId)
    {
        if (trackId >= 0 && trackId < Tracks.Count)
        {
            for (int i = 0; i < Tracks.Count; i++)
            {
                if (i != trackId)
                {
                    Tracks[i].gameObject.SetActive(false);
                }
                else
                {
                    Tracks[trackId].gameObject.SetActive(true);
                    Tracks[trackId].StartTrack();
                }
            }
        }
    }
    #endregion
}
