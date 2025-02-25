using AirplanePhysics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System;



public class Track_Manager : MonoBehaviour
{
    #region VARIABLES
    [Header("Track Manager Properties")]
    public List<Track> Tracks = new List<Track>();

    [Header("Track Selector UI")]
    public Transform tracksContent;
    public GameObject trackSelectorPrefab;
    //[SerializeField] private List<UnityEngine.UI.Button> trackSelectorButtons = new List<UnityEngine.UI.Button>();
    [SerializeField] private Dictionary<int, UnityEngine.UI.Button> trackSelectorButtons = new Dictionary<int, UnityEngine.UI.Button>();

    [Header("Track Manager UI")]
    public GameObject statsPanel; 
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
        GenerateTracksSelectors();

        //StartTrack(1);
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

    private void GenerateTracksSelectors()
    {
        for(int i = 0; i < Tracks.Count; i++)
        {
            //Instanciate Button
            string id = i.ToString();
            GameObject trackSelector = Instantiate(trackSelectorPrefab, tracksContent);
            trackSelector.name = "Track " + id;
            
            //Get button Component 
            UnityEngine.UI.Button trackSelectorButton = trackSelector.GetOrAddComponent<UnityEngine.UI.Button>();
            trackSelectorButtons.Add(i,trackSelectorButton);

            //Change the visible name of the button
            TMP_Text buttonText = trackSelectorButtons[i].gameObject.GetComponentInChildren<TMP_Text>();
            buttonText.text = "Track " + id; ;
            trackSelectorButtons[i].onClick.AddListener(() => SelectTrack(id));
        }
    }

    
    public void SelectTrack(string trackId)
    {
        int id = 0;
        if(Int32.TryParse(trackId, out id))
        {
            if (_currentTrack != null)
            {
                Debug.Log("Deactivating " + _currentTrack.name + ".");
                _currentTrack.gameObject.SetActive(false);
                _currentTrack = null;
            }

            Debug.Log("New track ID " + trackId);

            if (id >= 0 && id < Tracks.Count)
            {
                _currentTrack = Tracks[id];
                _currentTrack.gameObject.SetActive(true);
            }
        };
        if (!statsPanel.activeSelf) 
        {
            statsPanel.SetActive(true);
        }
    }

    public void StartTrack()
    {
       _currentTrack.StartTrack();
    }

    private void CompletedTrack()
    {
        Debug.Log("Track Manager: Track Completed");
        if (currentAirplane != null)
        {
            StartCoroutine(WaitForLanding());
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

    private void UpdateTrackUI()
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
            scoreText.text = "Score: " + _currentTrack.CurrentScore.ToString("0000");
        }
    }
    #endregion
}
