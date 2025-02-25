using UnityEngine;

public class ShowHideTracksSelectorPanel : MonoBehaviour
{

    [SerializeField] private enum PanelState
    {
        SHOWN, 
        HIDED
    }
    private PanelState state = PanelState.HIDED;

    [Header("Transition properties")]
    public float transitionDuration = 1.0f;
    [SerializeField] private LeanTweenType showEaseType;
    [SerializeField] private LeanTweenType hideEaseType;

    [SerializeField] private Vector3 hidePos,showPos;  
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hidePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) { ChangePanelState(); }
    }

    private void ChangePanelState()
    {
        switch (state) 
        {
            case PanelState.HIDED: //Panel is hided, we have to show it
                LeanTween.moveX(gameObject, showPos.x, transitionDuration).setEase(showEaseType);
                state = PanelState.SHOWN;
                break;
            case PanelState.SHOWN: //Panel is shown, we have to hide it
                LeanTween.moveX(gameObject, hidePos.x, transitionDuration).setEase(hideEaseType);
                state = PanelState.HIDED;
                break;
            default:
                break;
        }
    }
}
