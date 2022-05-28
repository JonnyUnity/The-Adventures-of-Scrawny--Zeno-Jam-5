using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private Transform _openPosition;
    [SerializeField] private Transform _closedPosition;

    [SerializeField] private bool _isOpen = false;

    [SerializeField] private EventChannelSO _OnToggleHatch;
    [SerializeField] private EventChannelSO _OnOpenHatch;
    [SerializeField] private EventChannelSO _OnCloseHatch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        _OnToggleHatch.OnEventRaised += ToggleHatch;
        _OnOpenHatch.OnEventRaised += OpenHatch;
        _OnCloseHatch.OnEventRaised += CloseHatch;
    }

    private void OnDisable()
    {
        _OnToggleHatch.OnEventRaised -= ToggleHatch;
        _OnOpenHatch.OnEventRaised -= OpenHatch;
        _OnCloseHatch.OnEventRaised -= CloseHatch;
    }



    public void ToggleHatch()
    {
        if (_isOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }


        _isOpen = !_isOpen;

    }

    public void OpenHatch()
    {
        if (_isOpen)
            return;

        OpenDoor();

        _isOpen = true;
    }

    public void CloseHatch()
    {
        if (!_isOpen)
            return;

        CloseDoor();

        _isOpen = false;


    }



    private void OpenDoor()
    {
        _door.transform.position = _openPosition.position;
    }


    private void CloseDoor()
    {
        _door.transform.position = _closedPosition.position;
    }

}
