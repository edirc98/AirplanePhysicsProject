using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;


[System.Serializable] public class FloatEvent : UnityEvent<float>{}
public class Gate : MonoBehaviour
{
    #region VARIABLES
    [Header("Gates Properties")]
    [Tooltip("Base Crossing direction is Transform Forward of the gate")]
    public bool reversedCrossingDirection = false;
    public bool isActive = false;
    [Range(0f, 1f)] public float crossingSensitivity;

    [Header("Gate Colors & Efects")]
    public Color gateActiveColor;
    public Color gateInactiveColor;
    public PingPong gatePingPong;

    [Header("UI Properties")]
    [SerializeField] private Material gateVisualMaterial;
    [SerializeField] private List<Image> gateArrowImages = new List<Image>();

    [Header("Gate Events")]
    public FloatEvent OnClearedGate = new FloatEvent();
    public UnityEvent OnFailedGate = new UnityEvent();


    //Privates
    private Vector3 gateDirection;
    private bool isCleared = false;

    //Gate score computation
    [SerializeField] private float gateCheckRadius; 
    #endregion

    #region UNITY BUILT-IN METHODS
    private void Awake()
    {
        InitGateProperties();
    }
    void Start()
    {
        gateDirection = GetGateDirection();
        ChangeGateColor(isActive);
        gatePingPong.SetActive(isActive);

        gateCheckRadius = (GetComponent<BoxCollider>().size.x / 2.0f) + 2.0f; //+2 taking into acount the wingspan of the plane,
                                                                              //because the tip of the wing can collide and the transform of the plane can be outside the check radius
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && isActive && !isCleared)
        {
            float distToCenter = Vector2.Distance(other.transform.position, transform.position); //How far from center the place cross the gate
            //Compare the dist to the center with the radius and return a 1 to 0 value, the closer to the center the better
            float distPercent = 1 - (Mathf.InverseLerp(0, gateCheckRadius, distToCenter));

            Debug.Log("Player crossed gate -> " + transform.gameObject.name);

            CheckCrossingDirection(other.transform.forward, distPercent);
        }
    }

    private void OnDrawGizmos()
    {
        gateDirection = GetGateDirection();

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + (gateDirection * 5.0f));
        Gizmos.DrawSphere(transform.position + (gateDirection * 5.0f), 1f);

    }
    #endregion

    #region CUSTOM METHODS

    private void InitGateProperties()
    {
        gateVisualMaterial = GetComponentInChildren<MeshRenderer>().material;
        gateArrowImages = GetComponentsInChildren<Image>().ToList();
        gatePingPong = GetComponentInChildren<PingPong>();
    }
    public void ActivateGate()
    {
        isActive = true;
        ChangeGateColor(isActive);
        gatePingPong.SetActive(isActive);
    }

    public void DeactivateGate() 
    {
        isActive = false;
        isCleared = false;
        ChangeGateColor(isActive);
        gatePingPong.SetActive(isActive);
    }

    private void CheckCrossingDirection(Vector3 direction, float distPercent)
    {
        float dot = Vector3.Dot(gateDirection, direction);
        if (dot > crossingSensitivity)
        {
            //Debug.Log("Crossing Succesfull");
            isCleared = true;

            if(OnClearedGate != null)
            {
                OnClearedGate.Invoke(distPercent);
            }
            DeactivateGate();
        }
        else 
        {
            //Debug.Log("Crossing Failed");
            if(OnFailedGate != null)
            {
                OnFailedGate.Invoke();
            }
        }
    }

    private void ChangeGateColor(bool isGateActive)
    {
        if (isGateActive) 
        { 
            gateVisualMaterial.color = gateActiveColor; 
            ChangeArrowsColor(isGateActive);
        }
        else 
        {
            gateVisualMaterial.color = gateInactiveColor;
            ChangeArrowsColor(isGateActive);
        }
    }

    private void ChangeArrowsColor(bool isGateActive)
    {
        foreach (Image image in gateArrowImages)
        {
            if (isGateActive)
            {
                image.color = gateActiveColor;
            }
            else
            {
                image.color = gateInactiveColor;
            }
        }
    }

    public Vector3 GetGateDirection()
    {
        if (!reversedCrossingDirection)
        {
            return transform.forward;
        }
        else return -transform.forward;
    }

    #endregion
}
