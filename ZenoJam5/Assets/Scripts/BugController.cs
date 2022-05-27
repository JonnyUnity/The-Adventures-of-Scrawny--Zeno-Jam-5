using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _groundContact;

    private Transform _transform;
    private Rigidbody2D _rigidBody;

    private LightSensor _lightSensor;

    private LightSource _currentLightTarget;

    private void Awake()
    {
        _transform = transform;
        _rigidBody = GetComponent<Rigidbody2D>();
        _lightSensor = GetComponent<LightSensor>();
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


    public void MoveTowardsTarget()
    {

        var dir = _currentLightTarget.Destination - (Vector2)_groundContact.position;

        if (dir.magnitude > 0.5f)
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


    public bool CanSeeLight()
    {
        LightSource lightSource = _lightSensor.Ping();
        //if (lightSource != null)
        //{
            Debug.Log(lightSource);
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


}
