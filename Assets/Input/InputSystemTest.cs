using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemTest : MonoBehaviour
{
    private Rigidbody rb;
    private Test_InputActions testActions;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        testActions = new Test_InputActions();
        testActions.BaseActionMap.Enable();
        testActions.BaseActionMap.Jump.performed += Jump;
        //testActions.BaseActionMap.Movement.performed += Movement;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.AddForce(Vector3.up * 3.0f, ForceMode.Impulse);
            Debug.Log("Jump: " + context.phase);
        }
    }


    private void Update()
    {
        ContiniousMovement();
    }
    public void Movement(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        Vector2 moveDir = context.ReadValue<Vector2>();
        float speed = 2.0f;
        rb.AddForce(new Vector3(moveDir.x,0.0f,moveDir.y) * speed, ForceMode.Force);
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
