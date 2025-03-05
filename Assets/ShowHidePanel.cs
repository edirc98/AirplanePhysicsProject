using UnityEngine;

public class ShowHidePanel : MonoBehaviour
{
    #region VARIABLES
    public enum PanelState
    {
        SHOWN, 
        HIDED
    }
    public enum MoveAxis
    {
        X,
        Y,
        Z
    }
    [SerializeField] private PanelState state = PanelState.HIDED;
    [SerializeField] private MoveAxis moveAxis = MoveAxis.X;


    [Header("Transition properties")]
    public float transitionDuration = 1.0f;
    [SerializeField] private LeanTweenType showEaseType;
    [SerializeField] private LeanTweenType hideEaseType;

    [SerializeField] private Vector3 hidePos,showPos;
    #endregion

    #region PROPERTIES
    public PanelState CurrentState { get { return state; } }
    #endregion

    #region UNTIY BUILT-IN METHODS
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
    #endregion

    #region CUSTOM METHODS
    public void ChangePanelState()
    {
        switch (state) 
        {
            case PanelState.HIDED: //Panel is hided, we have to show it
                switch (moveAxis)
                {
                    case MoveAxis.X:
                        LeanTween.moveX(gameObject, showPos.x, transitionDuration).setEase(showEaseType);
                        break;
                    case MoveAxis.Y:
                        LeanTween.moveY(gameObject, showPos.y, transitionDuration).setEase(showEaseType);
                        break;
                    case MoveAxis.Z:
                        LeanTween.moveZ(gameObject, showPos.z, transitionDuration).setEase(showEaseType);
                        break;
                    default:
                        break;
                }
                state = PanelState.SHOWN;
                break;
            case PanelState.SHOWN: //Panel is shown, we have to hide it
                switch (moveAxis)
                {
                    case MoveAxis.X:
                        LeanTween.moveX(gameObject, hidePos.x, transitionDuration).setEase(hideEaseType);
                        break;
                    case MoveAxis.Y:
                        LeanTween.moveY(gameObject, hidePos.y, transitionDuration).setEase(hideEaseType);
                        break;
                    case MoveAxis.Z:
                        LeanTween.moveZ(gameObject, hidePos.z, transitionDuration).setEase(hideEaseType);
                        break;
                    default:
                        break;
                }
                state = PanelState.HIDED;
                break;
            default:
                break;
        }
        #endregion

    }
}
