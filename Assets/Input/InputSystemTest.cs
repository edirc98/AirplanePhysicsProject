using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemTest : MonoBehaviour
{
    private Rigidbody rb;
    private Test_InputActions testActions;

    Vector2 screenCenter;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        testActions = new Test_InputActions();
        testActions.BaseActionMap.Enable();
        testActions.BaseActionMap.Jump.performed += Jump;
        //testActions.BaseActionMap.Movement.performed += Movement;

        screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.AddForce(Vector3.up * 3.0f, ForceMode.Impulse);
            Debug.Log("Jump: " + context.phase);
        }
    }


    private void FixedUpdate()
    {
        //GetMousePos();
        GetMousePosFromInputSystem();
        //ContiniousMovement();
    }
    public void Movement(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        Vector2 moveDir = context.ReadValue<Vector2>();
        float speed = 2.0f;
        rb.AddForce(new Vector3(moveDir.x,0.0f,moveDir.y) * speed, ForceMode.Force);
    }

    private void GetMousePos()
    {
        Vector2 mousePos = Mouse.current.position.value;
        //Vector2 mousePosCentered = new Vector2(mousePos.x -= screenCenter.x, mousePos.y -= screenCenter.y);
        //Vector2 mouseDir = mousePosCentered - Vector2.zero;

        float normalizedX = Mathf.InverseLerp(0,Screen.width, mousePos.x);
        float scaledNormalizedX = Mathf.Lerp(-1.0f,1.0f,normalizedX);

        float normalizedY = Mathf.InverseLerp(0, Screen.height, mousePos.y);
        float scaledNormalizedY = Mathf.Lerp(-1.0f, 1.0f, normalizedY);

        Debug.Log("Mouse pos Y: " + mousePos.x);
        Debug.Log("Normalized Y: " + normalizedY);
        Debug.Log("Scaled Normalized Y: " + scaledNormalizedY);

    }
    private void GetMousePosFromInputSystem()
    {
        Vector2 pos = testActions.BaseActionMap.MouseMovement.ReadValue<Vector2>();
        Debug.Log(pos); 
    }

    public void ContiniousMovement()
    {
        Vector2 moveDir = testActions.BaseActionMap.Movement.ReadValue<Vector2>();
        float speed = 2.0f;
        rb.AddForce(new Vector3(moveDir.x, 0.0f, moveDir.y) * speed, ForceMode.Force);
    }

    private void OnDisable()
    {
        testActions.Disable();
    }
}
