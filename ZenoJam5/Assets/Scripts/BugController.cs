using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _horizontalFallSpeed;
    [SerializeField] private Transform _groundContact;
    [SerializeField] private LayerMask _ignorePlayerMask;

    [SerializeField] protected EventChannelSO _reachedGoal;

    private Transform _transform;
    private Rigidbody2D _rigidBody;
    private LightSensor _lightSensor;
    private LightSource _currentLightTarget;

    private void OnEnable()
    {
        _reachedGoal.OnEventRaised += ReachedGoal;
    }

    private void OnDisable()
    {
        _reachedGoal.OnEventRaised -= ReachedGoal;
    }

    private void Awake()
    {
        _transform = transform;
        _rigidBody = GetComponent<Rigidbody2D>();
        _lightSensor = GetComponent<LightSensor>();
    }


    private bool IsGrounded()
    {
        Debug.DrawRay(_groundContact.position, Vector2.down);
        
        var hit =  Physics2D.Raycast(_groundContact.position, Vector2.down, 0.1f, _ignorePlayerMask);

        return (hit.collider != null);        

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



    public void MoveTowardsTarget()
    {
        
        //if (!IsGrounded())
        //{
        //    _rigidBody.velocity = new Vector2(_horizontalFallSpeed, _rigidBody.velocity.y);
        //    return;
        //}

        float speed = IsGrounded() ? _moveSpeed : _horizontalFallSpeed;

        var dir = _currentLightTarget.Destination - (Vector2)_groundContact.position;

        //Debug.Log("Magnitude " + dir.magnitude);
        if (dir.magnitude > 0.1f)
        {

            _rigidBody.velocity = _moveSpeed * Vector2.right;
            
            if (dir.x < 0) // target is to the right
            {
                _rigidBody.velocity *= -1;

                // face left;
            }
            else
            {
                // face right;
            }
         

        }       
        

    }


    public void ResetTarget()
    {
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
        _rigidBody.MovePosition(_currentLightTarget.Destination);
        _rigidBody.velocity = Vector2.zero;
    }

}
