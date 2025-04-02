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

    public enum RocketStatus
    {
        READY, 
        ONAIR,
        RELOADING
    }
    [SerializeField] private RocketStatus state = RocketStatus.READY;
    public RocketStatus Status { get { return state; } }
    #endregion
    #region UNITY BUILT-IN METHODS
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>(); 

    }

    #endregion
    #region CUSTOM METHODS
    public void ShotRocket()
    {
        _rb.linearVelocity = -transform.up * _speed;

        state = RocketStatus.ONAIR;
        ps_Flame.Play();
        ps_Trail.Play();
    }
    #endregion


}
