using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rocket : MonoBehaviour
{

    #region VARIABLES
    [Header("Rocket Characteristics")]
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _reloadTime = 5.0f;
    [Header("Rocket Components")]
    [SerializeField] private Rigidbody _rb; 

    [Header("Rocket Visuals")]
    [SerializeField] private ParticleSystem ps_Flame;
    [SerializeField] private ParticleSystem ps_Trail;

    private bool isReloading = false;

    public enum RocketStatus
    {
        READY, 
        ONAIR,
        RELOADING
    }
    [SerializeField] private RocketStatus status = RocketStatus.READY;
    public RocketStatus Status { get { return status; } set { status = value; } }
    public float ReloadTime { get { return _reloadTime; } }
    public bool IsReloading { get { return isReloading; } set { isReloading = value; } }
    #endregion
    #region UNITY BUILT-IN METHODS
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            Debug.Log("BUM!");
            _rb.isKinematic = true;
            gameObject.SetActive(false);
            status = RocketStatus.RELOADING;
        }
    }

    #endregion
    #region CUSTOM METHODS
    public void ShotRocket()
    {
        _rb.isKinematic = false;
        _rb.linearVelocity = -transform.up * _speed;


        status = RocketStatus.ONAIR;
        ps_Flame.Play();
        ps_Trail.Play();
    }
    #endregion


}
