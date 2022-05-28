using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldButton : MonoBehaviour
{

    //[SerializeField] private GameEvent _OnButtonActivated;
    //[SerializeField] private GameEvent _OnButtonDeactivated;

    [SerializeField] private EventChannelSO _OnButtonActivated;
    [SerializeField] private EventChannelSO _OnButtonDeactivated;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        _OnButtonActivated.RaiseEvent();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _OnButtonDeactivated.RaiseEvent();
    }


}