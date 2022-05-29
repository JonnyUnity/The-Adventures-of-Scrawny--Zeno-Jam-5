using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSensor : MonoBehaviour
{
    [SerializeField] private Transform _sensor;
    [SerializeField] private LayerMask _lightSourceMask;
    [SerializeField] private LayerMask _ignorePlayerMask;
    [SerializeField] private float _sensorDistance;

    private Transform _transform;
    private Collider2D[] results;

    private void Awake()
    {
        _transform = transform;
    }

    public LightSource Ping()
    {
        //Collider2D result = Physics2D.OverlapCircle(_transform.position, 5f, _lightSourceMask);

        //if (result != null)
        //{
        //    if (result.gameObject.CompareTag("LightSource"))
        //    {
        //        if (result.gameObject.TryGetComponent(out LightSource ls))
        //        {
        //            Debug.DrawRay(_transform.position, transform.TransformDirection(Vector2.right * 5f));
        //            Vector2 dirToTarget = (result.gameObject.transform.position - transform.position).normalized;

        //            float distToTarget = Vector2.Distance(_transform.position, result.gameObject.transform.position);

        //            if (Physics2D.Raycast(_transform.position, transform.TransformDirection(Vector2.left), 5f))
        //            {
        //                return ls;
        //            }                    
        //        }
        //    }
        //}
        Debug.DrawRay(_sensor.position, Vector2.left * _sensorDistance);
        Debug.DrawRay(_sensor.position, Vector2.right * _sensorDistance);

        float? leftDistance = null;
        float? rightDistance = null;
        LightSource leftLightSource = null;
        LightSource rightLightSource = null;

        RaycastHit2D hitInfo = Physics2D.Raycast(_sensor.position, Vector2.left * _sensorDistance, _sensorDistance, _ignorePlayerMask);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("LightSource"))
            {
                var leftLS = hitInfo.collider.gameObject;

                leftDistance = DistanceToLightSource(leftLS);

                if (leftLS.TryGetComponent(out LightSource ls))
                {
                    leftLightSource = ls;
                }
            }
        }

        hitInfo = Physics2D.Raycast(_sensor.position, Vector2.right * _sensorDistance, _sensorDistance, _ignorePlayerMask);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("LightSource"))
            {
                var rightLS = hitInfo.collider.gameObject;

                rightDistance = DistanceToLightSource(rightLS);

                if (hitInfo.collider.gameObject.TryGetComponent(out LightSource ls))
                {
                    rightLightSource = ls;
                }
            }
        }

        if (leftLightSource != null && rightLightSource != null)
        {
            if (leftDistance.Value > rightDistance.Value)
            {
                return leftLightSource;
            }
            else
            {
                return rightLightSource;
            }
        }
        else if (leftLightSource != null)
        {
            return leftLightSource;
        }
        else if (rightLightSource != null)
        {
            return rightLightSource;
        }


        return null;

    }

    private float DistanceToLightSource(GameObject lightSource)
    {
        return Vector2.Distance(_transform.position, lightSource.transform.position);

    }

}
