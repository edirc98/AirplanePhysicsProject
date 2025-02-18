using UnityEngine;

public class PingPong : MonoBehaviour
{
    #region VARIABLES
    [Header("Ping Pong Properties")]
    public bool isActive = false;
    public float pingPongSpeed = 1.0f;
    public float minValue = 0.6f;
    public float maxValue = 1.1f;

    private Vector3 startLocalScale;

    #endregion


    #region UNITY BUILT-IN METHODS

    private void Awake()
    {
        startLocalScale = transform.localScale;
    }
    void Update()
    {
        if (isActive)
        {
            float pingpong = minValue + Mathf.PingPong((pingPongSpeed * Time.time) - minValue, maxValue - minValue);
            transform.localScale = new Vector3(pingpong, pingpong, transform.localScale.z);
        }
        
    }

    public void SetActive(bool active)
    {
        if (active) { isActive = true; }
        else
        {
            isActive = false;
            transform.localScale = startLocalScale;
        }
    }
    #endregion
}
