using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _horizontalFallSpeed;
    [SerializeField] private Transform _groundContact;
    [SerializeField] private LayerMask _ignorePlayerMask;

    [SerializeField] private Transform _groundTest1;
    [SerializeField] private Transform _groundTest2;

    [Header("Audio")]
    [SerializeField] private AudioClip _walkClip;

    [Header("Events")]
    [SerializeField] protected EventChannelSO _reachedGoal;
    [SerializeField] private EventChannelSO _restartLevel;

    private Transform _transform;
    private Rigidbody2D _rigidBody;
    private LightSensor _lightSensor;
    private LightSource _currentLightTarget;
    private Animator _animator;
    protected AudioSource _audioSource;


    private void OnEnable()
    {
        _restartLevel.OnEventRaised += StopInPlace;
    }

    private void OnDisable()
    {
        _restartLevel.OnEventRaised -= StopInPlace;
    }

    private void Awake()
    {
        _transform = transform;
        _rigidBody = GetComponent<Rigidbody2D>();
        _lightSensor = GetComponent<LightSensor>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }


    private bool IsGrounded()
    {
        Debug.DrawRay(_groundTest1.position, Vector2.down);
        Debug.DrawRay(_groundTest2.position, Vector2.down);

        var hit =  Physics2D.Raycast(_groundTest1.position, Vector2.down, 0.1f, _ignorePlayerMask);

        bool test1 = (hit.collider != null);

        hit = Physics2D.Raycast(_groundTest2.position, Vector2.down, 0.1f, _ignorePlayerMask);
        bool test2 = (hit.collider != null);

        return (test1 || test2);        

        //return Physics.Raycast(_groundContact.position, Vector2.down, 0.1f, _ignorePlayerMask);
    }


    private void Update()
    {
        
        //LightSource lightSource = _lightSensor.Ping();
        //if (_currentLightTarget == null && lightSource != _currentLightTarget)
        //{
        //    Debug.Log("New light!");
        //    _currentLightTarget = lightSource;
        //}
        //else if (lightSource == null && _currentLightTarget != null)
        //{
        //    Debug.Log("Lost light!");
        //    _currentLightTarget = null;
        //}
    }

    public void StopInPlace()
    {
        _animator.SetBool("IsWalking", false);
        _audioSource.Stop();
        _rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
    }


    protected virtual void ReachedGoal()
    {
        Debug.Log("Reached goal!");


        StopInPlace();
    }


    //private IEnumerator ReachedGoalCoroutine()
    //{
    //    // play animation?


    //}
    public void StartWalking()
    {
        _animator.SetBool("IsWalking", true);
        _audioSource.clip = _walkClip;
        _audioSource.loop = true;
        _audioSource.Play();
    }


    public void MoveTowardsTarget()
    {

        //if (!IsGrounded())
        //{
        //    _rigidBody.velocity = new Vector2(_horizontalFallSpeed, _rigidBody.velocity.y);
        //    //return;
        //}
        //else
        //{
        bool isGrounded = IsGrounded();
        float speed = isGrounded ? _moveSpeed : _horizontalFallSpeed;
        if (!isGrounded)
        {
            Debug.Log(_rigidBody.velocity);
        //    _rigidBody.velocity = Vector2.zero;
        }
        //else
        //{
        Debug.Log("SPeed " + speed);

        var dir = _currentLightTarget.Destination - (Vector2)_groundContact.position;

        var xdist = _currentLightTarget.Destination.x - _groundContact.position.x;

            
        if (dir.magnitude > 0.05f)
        {

            _rigidBody.velocity = speed * Vector2.right;
            

            if (dir.x < 0) // target is to the left
            {
                _rigidBody.velocity *= -1;
                _transform.localScale = new Vector2(-1, 1);
                // face left;
            }
            else
            {
                // face right;
                _transform.localScale = new Vector2(1, 1);

            }


        }
        //}

    }


    public void ResetTarget()
    {
        _animator.SetBool("IsWalking", false);
        _audioSource.Stop();
        _currentLightTarget = null;
        _rigidBody.velocity = Vector2.zero;
    }


    public bool CanSeeLight()
    {
        LightSource lightSource = _lightSensor.Ping();
        //if (lightSource != null)
        //{
            //Debug.Log(lightSource);
        //}

        if (_currentLightTarget != null && !_currentLightTarget.isActiveAndEnabled)
        {
            _currentLightTarget = null; // clear target if light source deactivated
        }

        if (_currentLightTarget == null && lightSource != _currentLightTarget)
        {
            Debug.Log("New light!");
            _currentLightTarget = lightSource;
        }
        else if (lightSource == null && _currentLightTarget != null)
        {
            Debug.Log("Lost light!");
            _currentLightTarget = null;
        }

        return (lightSource != null);
    }


    public float? DistanceToCurrentLightTarget()
    {
        CanSeeLight();

        if (_currentLightTarget == null)
            return null;

        float dist = Vector2.Distance(_groundContact.position, _currentLightTarget.Destination);

        return dist;
    }


    public void PositionOnCurrentLightTarget()
    {
        _audioSource.Stop();
        _animator.SetBool("IsWalking", false);
        _rigidBody.MovePosition(_currentLightTarget.Destination);
        _rigidBody.velocity = Vector2.zero;
    }

}