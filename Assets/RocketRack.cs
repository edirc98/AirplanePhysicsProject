using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[System.Serializable]
public struct AttachPoint
{
    public Transform Point;
    public Rocket Rocket;

    public AttachPoint(Transform position, Rocket rocket)
    {
        Point = position;
        Rocket = rocket;
    }
}

public class RocketRack : MonoBehaviour
{
    #region VARIABLES
    [Header("Rocket Prefab")]
    [SerializeField] private GameObject _rocketPrefab;
    [Header("Rack Properties")]
    [SerializeField] private Transform rackAttachPointsParent; 
    [SerializeField] private List<AttachPoint> _rackAttachPoints;
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        SetupRockets();
    }
    void Start()
    {

    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            ShootRackRocket();
        }
    }
    #endregion

    #region METHODS
    private void SetupRockets()
    {
        foreach (Transform rackPoint in rackAttachPointsParent)
        {
            GameObject newRocket = Instantiate(_rocketPrefab, rackPoint.position, Quaternion.identity, rackPoint);
            newRocket.transform.up = -rackPoint.forward;

            Rocket rocket = newRocket.GetComponent<Rocket>();


            AttachPoint attachedRocket = new AttachPoint(rackPoint, rocket);
            _rackAttachPoints.Add(attachedRocket);
        }
    }

    private void ShootRackRocket()
    {
        foreach (AttachPoint rackPoint in _rackAttachPoints)
        {
            if (rackPoint.Rocket.Status == Rocket.RocketStatus.READY)
            {
                rackPoint.Rocket.ShotRocket();
                return;
            }
        }
    }
    #endregion

}
