using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Interactable
{
    [Header("Lamp Data")]
    [SerializeField] private Transform _groundContact;
    [SerializeField] private Transform _lightStart;
    [SerializeField] private GameObject _lightRay;

    [SerializeField] private LayerMask _ignoreLightSourceMask;

    [SerializeField] private EventChannelSO _OnToggleLight;
    [SerializeField] private EventChannelSO _OnLightOn;
    [SerializeField] private EventChannelSO _OnLightOff;

    [SerializeField] private bool _startWithLightOn;
    private bool _IsLightOn;

    private void OnEnable()
    {
        _OnToggleLight.OnEventRaised += ToggleLight;
        //_OnLightOn.OnEventRaised += LightOn;
        //_OnLightOff.OnEventRaised += LightOff;
    }

    private void OnDisable()
    {
        _OnToggleLight.OnEventRaised -= ToggleLight;
        //_OnLightOn.OnEventRaised -= LightOn;
        //_OnLightOff.OnEventRaised -= LightOff;

    }



    private void Awake()
    {
        SetLightDimensions();
    }


    // Start is called before the first frame update
    private void Start()
    {
        // set ground contact position.
        if (_startWithLightOn) LightOn();
    }




    private void SetLightDimensions()
    {
        RaycastHit2D hit = Physics2D.Raycast(_lightStart.position, Vector2.down, Mathf.Infinity, _ignoreLightSourceMask);

        if (hit.collider != null)
        {
            float rayHeight = Mathf.Abs(hit.point.y - _lightStart.position.y);
            _lightRay.transform.localScale = new Vector2(1, rayHeight);

            Vector2 middleDistance = (hit.point + (Vector2)_lightStart.position)/2;
            _lightRay.transform.position = middleDistance;


            _groundContact.position = hit.point;
            _lightRay.SetActive(false);
        }

    }


    private void LightOff()
    {
        if (!_IsLightOn)
            return;

        _lightRay.SetActive(false);

        _IsLightOn = false;

    }

    private void LightOn()
    {
        if (_IsLightOn)
            return;

        _lightRay.SetActive(true);

        _IsLightOn = true;
    }

    private void ToggleLight()
    {
        
        if (_IsLightOn)
        {
            LightOff();
        }
        else
        {
            LightOn();
        }


    }


}
