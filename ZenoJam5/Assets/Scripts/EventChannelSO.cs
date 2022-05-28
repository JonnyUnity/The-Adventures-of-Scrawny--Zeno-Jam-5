using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Event Channel")]
public class EventChannelSO : ScriptableObject
{

    public UnityAction OnEventRaised;


    public void RaiseEvent()
    {
        Debug.Log("Raise Event!");
        OnEventRaised?.Invoke();
    }

}
