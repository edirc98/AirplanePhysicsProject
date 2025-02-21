using AirplanePhysics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro; 


public class Track_Manager : MonoBehaviour
{
    #region VARIABLES
    [Header("Track Manager Properties")]
    public List<Track> Tracks = new List<Track>();

    [Header("Track Manager UI")]
    public TMP_Text gateText;
    public TMP_Text timeText;
    public TMP_Text scoreText; 

    [Header("Track Manager Events")]
    public UnityEvent OnCompletedRace = new UnityEvent();

    public Airplane_Controller currentAirplane;

    private Track _currentTrack; 
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
        if (_currentTrack != null) 
        {
            UpdateTrackUI();
        }
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
        if (currentAirplane != null)
        {
            StartCoroutine(WaitForLanding());
        }
    }

    public void StartTrack(int trackId)
    {
        if (trackId >= 0 && trackId < Tracks.Count)
        {
            for (int i = 0; i < Tracks.Count; i++)
            {
                if (i == trackId)
                {
                    Tracks[trackId].gameObject.SetActive(true);
                    Tracks[trackId].StartTrack();
                    _currentTrack = Tracks[trackId];
                }
                else
                {
                    Tracks[i].gameObject.SetActive(false);
                }
            }
        }
    }

    private IEnumerator WaitForLanding()
    {
        while(currentAirplane.State != AIRPLANE_STATE.LANDED)
        {
            yield return null;
        }

        if (OnCompletedRace != null)
        {
            Debug.Log("Landed Succesfull. Race Completed");
            OnCompletedRace.Invoke();
        }
    }

    private void UpdateTrackUI() //TODO
    {
        if(gateText != null)
        {
            gateText.text = "Gates: " + _currentTrack.CurrentGateID.ToString() + " / " + _currentTrack.TotalGates.ToString();
        }
        if(timeText != null)
        {
            string mins = _currentTrack.CurrentMinutes.ToString("00");
            string secs = _currentTrack.CurrentSeconds.ToString("00");
            timeText.text = mins +" : "+ secs;
        }
        if(scoreText != null)
        {

        }
    }
    #endregion
}
