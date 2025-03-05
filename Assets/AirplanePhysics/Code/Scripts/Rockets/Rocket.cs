using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rocket : MonoBehaviour
{

    #region VARIABLES
    [Header("Rocket Characteristics")]
    [SerializeField] private float _speed = 5.0f;
    [Header("Rocket Components")]
    [SerializeField] private Rigidbody _rb; 

    [Header("Rocket Visuals")]
    [SerializeField] private ParticleSystem ps_Flame;
    [SerializeField] private ParticleSystem ps_Trail;

    public enum RocketState
    {
        HOLDED, 
        SHOT
    }
    private RocketState state = RocketState.HOLDED; 
    public RocketState CurrentRocketState { get { return state; } }
    #endregion
    #region UNITY BUILT-IN METHODS
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>(); 

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShotRocket(); 
        }
    }
    #endregion
    #region CUSTOM METHODS
    public void ShotRocket()
    {
        _rb.linearVelocity = -transform.up * _speed;

        state = RocketState.SHOT;
        ps_Flame.Play();
        ps_Trail.Play();
    }
    #endregion


}
