using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;

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
    public UnityEvent onClearedGate = new UnityEvent();
    public UnityEvent onFailedGate = new UnityEvent();

    //Privates
    private Vector3 gateDirection;
    #endregion

    #region UNITY BUILT-IN METHODS
    private void Awake()
    {
        gateVisualMaterial = GetComponentInChildren<MeshRenderer>().material;
        gateArrowImages = GetComponentsInChildren<Image>().ToList();
        gatePingPong = GetComponentInChildren<PingPong>();
    }
    void Start()
    {
        gateDirection = GetGateDirection();
        ChangeGateColor(isActive);
        gatePingPong.SetActive(isActive);
       
    }

    private void Update()
    {
        TEST_GATE();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player crossed gate -> " + transform.gameObject.name);
            CheckCrossingDirection(other.transform.forward);
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

    public void ActivateGate()
    {
        isActive = true;
        ChangeGateColor(isActive);
        gatePingPong.SetActive(isActive);
    }

    public void DeactivateGate() 
    {
        isActive = false;
        ChangeGateColor(isActive);
        gatePingPong.SetActive(isActive);
    }

    private void CheckCrossingDirection(Vector3 direction)
    {
        float dot = Vector3.Dot(gateDirection, direction);
        if (dot > crossingSensitivity)
        {
            Debug.Log("Crossing Succesfull");
            if(onClearedGate != null)
            {
                onClearedGate.Invoke();
            }
            
        }
        else 
        {
            Debug.Log("Crossing Failed");
            if(onFailedGate != null)
            {
                onFailedGate.Invoke();
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


    //DELETE ONCE TESTED
    private void TEST_GATE()
    {
        ChangeGateColor(isActive);
        gatePingPong.SetActive(isActive);
    }
    #endregion
}
